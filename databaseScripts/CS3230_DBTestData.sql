-- Test data for the heathcare project. Run after CS3230_InitialDBCreationScript.sql on empty tables.
-- To restart, rerun CS3230_InitialDBCreationScript.sql first.

-- ----------------------------------
-- Users for login/logout testing
-- ----------------------------------

-- Nurse: Emily Smith (username: esmith, password: nurse123)
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Emily', 'Smith', '1995-04-14', 'Female', '13 Birch St', 'Carrollton', 'GA', '30117', '770-555-0123');
SET @personId = last_insert_id();
INSERT INTO nurse (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('esmith', 'nurse123', 'nurse', @personId);

-- Nurse: David Rogers (username: drogers, password: nurse456)
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('David', 'Rogers', '1992-07-22', 'Male', '24 Willow Dr', 'Newnan', 'GA', '30263', '770-555-4567');
SET @personId = last_insert_id();
INSERT INTO nurse (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('drogers', 'nurse456', 'nurse', @personId);

-- Admin Donna Grace (username: dgrace, password: admin123)
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Donna', 'Grace', '1985-12-04', 'Female', '5 Spruce Ct', 'Carrollton', 'GA', '30116', '770-555-7421');
SET @personId = last_insert_id();
INSERT INTO administrator (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('dgrace', 'admin123', 'administrator', @personId);


-- ----------------------------------
-- Patients for search testing
-- ----------------------------------

-- Jane Daniels born 2001
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Jane', 'Daniels', '2001-11-17', 'Female', '123 Maple St', 'Carrollton', 'GA', '30117', '770-555-1313');
INSERT INTO patient (person_id)
VALUES (last_insert_id());

-- Jane Daniels born 1997, duplicate name, different birthday
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Jane', 'Daniels', '1997-05-06', 'Female', '12 Oak Ave', 'Newnan', 'GA', '30263', '770-555-0987');
INSERT INTO patient (person_id)
VALUES (last_insert_id());

-- John Daniels, duplicate last name, different first name
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('John', 'Daniels', '1994-10-28', 'Male', '9 Pine Rd', 'Carrollton', 'GA', '30116', '770-555-2424');
INSERT INTO patient (person_id)
VALUES (last_insert_id());

-- Mark Gray, duplicate birthday
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Mark', 'Gray', '2001-11-17', 'Male', '10 Kindelwood Dr', 'Newnan', 'GA', '30263', '770-555-2745');
INSERT INTO patient (person_id)
VALUES (last_insert_id());

-- Robert Lee, inactive patient
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Robert', 'Lee', '2003-12-17', 'Male', '12 Mill St', 'Carrollton', 'GA', '30116', '770-555-2763');
INSERT INTO patient (person_id, is_active)
VALUES (last_insert_id(), false);

-- ----------------------------------
-- Doctors and specialties for appointment testing
-- ----------------------------------

INSERT INTO specialty (specialty_name)
VALUES ('Family Medicine'), ('Cardiology'), ('Pediatrics');

-- Dr. Sarah Mitchell: Family Medicine
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Sarah', 'Mitchell', '1980-02-14', 'Female', '200 Mill St', 'Carrollton', 'GA', '30116', '770-555-2883');
INSERT INTO doctor (person_id)
VALUES (last_insert_id());
SET @doctorId = last_insert_id();
INSERT INTO doctor_specialty (doctor_id, specialty_id)
SELECT @doctorId, specialty_id
	FROM specialty
    WHERE specialty_name = 'Family Medicine';
    
-- Dr. James Owen: Cardiology and Family Medicine (2 specialties)
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('James', 'Owen', '1987-08-10', 'Male', '240 Willow St', 'Carrollton', 'GA', '30117', '770-555-8883');
INSERT INTO doctor (person_id)
VALUES (last_insert_id());
SET @doctorId = last_insert_id();
INSERT INTO doctor_specialty (doctor_id, specialty_id)
SELECT @doctorId, specialty_id
	FROM specialty
    WHERE specialty_name IN ('Cardiology', 'Family Medicine');
    
-- Dr. Sasha Daniels: Pediatrics
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Sasha', 'Daniels', '1989-11-21', 'Female', '24 Oak St', 'Carrollton', 'GA', '30117', '770-555-8888');
INSERT INTO doctor (person_id)
VALUES (last_insert_id());
SET @doctorId = last_insert_id();
INSERT INTO doctor_specialty (doctor_id, specialty_id)
SELECT @doctorId, specialty_id
	FROM specialty
    WHERE specialty_name = 'Pediatrics';
    
-- ----------------------------------
-- Existing appointments for testing available slots and double booking
-- ----------------------------------

-- Dr Mitchell is booked at 9:00 and 9:30 one week from today
INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_add(curdate(), interval 7 day), '09:00:00', 'Annual checkup', pa.patient_id, d.doctor_id
	FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
		 doctor d JOIN person dp ON d.person_id = dp.person_id
	WHERE pe.first_name = 'Jane' AND pe.date_of_birth = '2001-11-17'
		AND dp.last_name = 'Mitchell';
        
INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_add(curdate(), interval 7 day), '09:30:00', 'Follow up visit', pa.patient_id, d.doctor_id
	FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
		 doctor d JOIN person dp ON d.person_id = dp.person_id
	WHERE pe.first_name = 'John' AND pe.last_name = 'Daniels'
		AND dp.last_name = 'Mitchell';