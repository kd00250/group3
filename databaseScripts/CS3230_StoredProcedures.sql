-- ---------------------------------------------
-- get_most_performed_tests_duringdates
-- Gets the statistics that show the most performed tests during a specified period of time.
-- Only includes tests performed at least twice.
-- ---------------------------------------------

DROP PROCEDURE IF EXISTS get_most_performed_tests_duringdates;

DELIMITER $
CREATE PROCEDURE get_most_performed_tests_duringdates(IN start_date DATE, IN end_date DATE)
BEGIN
	DECLARE total_performed BIGINT DEFAULT 0;
    
    IF start_date IS NULL OR end_date IS NULL THEN
		SIGNAL SQLSTATE '45000'
			SET MESSAGE_TEXT = 'The start date and end sate are required.';
	END IF;
    
    IF start_date > end_date THEN
		SIGNAL SQLSTATE '45000'
			SET MESSAGE_TEXT = 'The start date cannot be after the end date.';
	END IF;
    
    SELECT COUNT(*) INTO total_performed
    FROM ordered_test
    WHERE datetime_performed >= start_date
		AND datetime_performed < DATE_ADD(end_date, INTERVAL 1 DAY);

	SELECT lt.test_code, lt.test_name, COUNT(*) AS times_performed, total_performed AS total_tests_performed,
			ROUND(COUNT(*) * 100 / total_performed, 2) AS percentage_performed,
            COUNT(CASE WHEN ot.test_result IS NOT NULL AND ot.is_abnormal = false THEN 1 END) AS normal_results,
            COUNT(CASE WHEN ot.test_result IS NOT NULL AND ot.is_abnormal = true THEN 1 END) AS abnormal_results
	FROM ordered_test ot
    JOIN lab_test lt ON ot.test_code = lt.test_code
    WHERE ot.datetime_performed >= start_date
		AND ot.datetime_performed < DATE_ADD(end_date, INTERVAL 1 DAY)
	GROUP BY lt.test_code, lt.test_name
    HAVING COUNT(*) >= 2
    ORDER BY times_performed DESC, lt.test_code DESC;
END$

DELIMITER ;


-- ------------------------------------------------------------------------------------
-- Author: Kenneth Dearman
-- Creates a visit based on the patient id and corresponding appointment information
-- Creates the visit only if the appointment time has not yet passed and there are no duplicate visits in visit table
-- -------------------------------------------------------------------------------------

DROP PROCEDURE IF EXISTS create_visit;

DELIMITER $$

CREATE PROCEDURE create_visit(
	IN p_patient_id INT,
	IN p_appointment_id INT,
    IN p_now DATETIME)
    BEGIN
		INSERT INTO visit (
			appointment_id,
            visit_datetime,
            is_finalized)
            SELECT a.appointment_id, p_now, FALSE
            FROM appointment a 
			WHERE a.appointment_id = p_appointment_id
				AND a.patient_id = p_patient_id
                AND TIMESTAMP(a.appointment_date, a.appointment_time) >= p_now
                AND NOT EXISTS (
					SELECT 1
                    FROM visit v
                    WHERE v.appointment_id = a.appointment_id);
			IF ROW_COUNT() = 0 THEN
				SIGNAL SQLSTATE '45000'
                SET MESSAGE_TEXT = 'The appointment is no longer available for starting a visit.';
			END IF;
            
            SELECT LAST_INSERT_ID() AS visit_id;
		END$$
DELIMITER ;

-- ------------------------------------------------------------------------------------
-- Author: Jareth Batty
-- Does a thing
-- -------------------------------------------------------------------------------------

DROP PROCEDURE IF EXISTS get_test_by_code;

DELIMITER $$

CREATE PROCEDURE get_test_by_code(
	IN t_test_code varchar(20),
    OUT test_code varchar(20),
    OUT test_name varchar(100),
    OUT low_value varchar(20),
    OUT high_value varchar(20),
    OUT unit_name varchar(30))
    BEGIN
		SELECT test_code = l.test_code, 
        test_name = l.test_name,
        low_value = l.low_value,
        high_value = l.high_value,
        unit_name = l.unit_name
        FROM lab_test as l 
        WHERE l.test_code = t_test_code;
	END$$
DELIMITER ;




