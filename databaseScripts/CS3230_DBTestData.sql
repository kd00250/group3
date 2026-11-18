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
VALUES ('esmith', '600000:6wweLGCD+QlFVHCgvpr+KA==:ykupLgjHllYVeMeTNSQWfNveAucMQHMcO0Pd4EiJdrs=', 'nurse', @personId);

-- Nurse: David Rogers (username: drogers, password: nurse456)
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('David', 'Rogers', '1992-07-22', 'Male', '24 Willow Dr', 'Newnan', 'GA', '30263', '770-555-4567');
SET @personId = last_insert_id();
INSERT INTO nurse (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('drogers', '600000:dELUrUER27wo9558SIwJxw==:EVQXOcVchWrA6GJ0qs3Ro/7oh0fCbHJhhCVSNxI8oFA=', 'nurse', @personId);

-- Nurse: Maria Lopez (username: mlopez, password: nurse789)
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Maria', 'Lopez', '1993-06-18', 'Female', '45 Cedar Ln', 'Carrollton', 'GA', '30117', '770-555-2184');
SET @personId = last_insert_id();
INSERT INTO nurse (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('mlopez', '600000:pNzIDppMgEaeKrSygOPpuw==:hufX5GwYqoEfktBkx0iVA++uVZXWPRGnb7B0JQBtkC4=', 'nurse', @personId);


-- Nurse: Andrew Wilson (username: awilson, password: nurse101)
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Andrew', 'Wilson', '1989-03-25', 'Male', '82 Pine Ridge Dr', 'Newnan', 'GA', '30263', '770-555-3291');
SET @personId = last_insert_id();
INSERT INTO nurse (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('awilson', '600000:N7U8RZM1e01CNazv8HiFcw==:st50sdLg5m3GHwc5OZtEKd3CSQFRRemU9TvA3DbO81A=', 'nurse', @personId);


-- Nurse: Taylor Green (username: tgreen, password: nurse202)
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Taylor', 'Green', '1997-09-12', 'Female', '17 Magnolia St', 'Carrollton', 'GA', '30116', '770-555-4176');
SET @personId = last_insert_id();
INSERT INTO nurse (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('tgreen', '600000:4MK4MXXm5FcMjvpZm5CJjQ==:7lN9l8FUGBwahxSt+lNq9wvBNW/YcsGrEu8q3TRJMdE=', 'nurse', @personId);

-- ----------------------------------
-- Admin Users
-- ----------------------------------

-- Admin Donna Grace (username: dgrace, password: admin123)
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Donna', 'Grace', '1985-12-04', 'Female', '5 Spruce Ct', 'Carrollton', 'GA', '30116', '770-555-7421');
SET @personId = last_insert_id();
INSERT INTO administrator (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('dgrace', '600000:GqoBfKQhTgZq8uoWlZEfwA==:++mmMNIwey+rSh5ouIRX5S7BxsqcyJT4CBdjzlne6RY=', 'administrator', @personId);

-- Admin Jon Snow (username: jsnow, password: admin456)
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Jon', 'Snow', '1990-09-05', 'Male', 'Winterfell lane', 'Carrollton', 'GA', '30115', '770-595-7423');
SET @personId = last_insert_id();
INSERT INTO administrator (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('jsnow', '600000:iWLAYohBUwjRNQ7rZKoWbw==:0O9xso8HAkj0TXUd/mhUiQ6NsW3G2gmER9XCIy1pD4w', 'administrator', @personId);

-- Admin Sansa Stark (username: sstark, password: admin789)
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Sansa', 'Stark', '1990-09-05', 'Female', 'Winterfell lane', 'Carrollton', 'GA', '30115', '404-991-7423');
SET @personId = last_insert_id();
INSERT INTO administrator (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('sstark', '600000:wFeDq1IIDS0XxL/cDwTF2g==:8vVniLKys4SiFXCg5xOwDOgWK+Z7Hp3+VW/Yo2kscsA=', 'administrator', @personId);

-- Admin Kevin Craft (username: kcraft, password: admin1011)
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Kevin', 'Craft', '1995-11-09', 'Male', 'PeachTree Lane', 'Atlanta', 'GA', '30215', '404-777-7483');
SET @personId = last_insert_id();
INSERT INTO administrator (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('kcraft', '600000:ffwY7SzoVgyl9eg0v4sFlw==:UP07sEVkdLgp2Yj7qln/KQR+Y3ql+ePWpcm7OVZ0cvE=', 'administrator', @personId);

-- Admin Olive Craft (username: ocraft, password: admin99)
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Olive', 'Craft', '2000-11-10', 'Female', 'PeachTree Lane', 'Atlanta', 'GA', '30215', '404-998-7401');
SET @personId = last_insert_id();
INSERT INTO administrator (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('ocraft', '600000:iMQDgpOgMxVnq5ThKxbSpg==:qWuhHtt9V5ipNfmY2+AaznZbJLTyreIfCkWv+ER/Rp0=', 'administrator', @personId);


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
VALUES ('Family Medicine'), ('Cardiology'), ('Pediatrics'), ('Dermatology'), ('Neurology');

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
    
-- Dr. Daniel Reed: Dermatology
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Daniel', 'Reed', '1978-04-05', 'Male', '15 Pine St', 'Carrollton', 'GA', '30117', '770-555-3301');
INSERT INTO doctor (person_id)
VALUES (last_insert_id());
SET @doctorId = last_insert_id();
INSERT INTO doctor_specialty (doctor_id, specialty_id)
SELECT @doctorId, specialty_id
    FROM specialty
    WHERE specialty_name = 'Dermatology';

-- Dr. Priya Shah: Neurology
INSERT INTO person (first_name, last_name, date_of_birth, gender, street_address, city, state, zip_code, phone_number)
VALUES ('Priya', 'Shah', '1983-12-11', 'Female', '28 Magnolia Ave', 'Newnan', 'GA', '30263', '770-555-3302');
INSERT INTO doctor (person_id)
VALUES (last_insert_id());
SET @doctorId = last_insert_id();
INSERT INTO doctor_specialty (doctor_id, specialty_id)
SELECT @doctorId, specialty_id
    FROM specialty
    WHERE specialty_name = 'Neurology';

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

INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_add(curdate(), interval 1 day), '09:00:00', 'Persistent cough', pa.patient_id, d.doctor_id
	FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
		 doctor d JOIN person dp ON d.person_id = dp.person_id
	WHERE pe.first_name = 'Mark' AND pe.last_name = 'Gray'
		AND dp.last_name = 'Owen';

INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_add(curdate(), interval 2 day), '11:15:00', 'Back pain', pa.patient_id, d.doctor_id
	FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
		 doctor d JOIN person dp ON d.person_id = dp.person_id
	WHERE pe.first_name = 'Jane' AND pe.date_of_birth = '1997-05-06'
		AND dp.last_name = 'Mitchell';

INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_add(curdate(), interval 3 day), '14:00:00', 'Allergy consultation', pa.patient_id, d.doctor_id
	FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
		 doctor d JOIN person dp ON d.person_id = dp.person_id
	WHERE pe.first_name = 'Robert' AND pe.last_name = 'Lee'
		AND dp.last_name = 'Daniels';
        
        
-- ----------------------------------
-- Additional future appointments
-- ----------------------------------

-- Jane Daniels (2001) with Dr. Reed: Skin rash examination
INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_add(curdate(), interval 4 day), '10:15:00', 'Skin rash examination', pa.patient_id, d.doctor_id
    FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
         doctor d JOIN person dp ON d.person_id = dp.person_id
    WHERE pe.first_name = 'Jane' AND pe.date_of_birth = '2001-11-17'
        AND dp.last_name = 'Reed';

-- John Daniels with Dr. Shah: Migraine consultation
INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_add(curdate(), interval 5 day), '13:00:00', 'Migraine consultation', pa.patient_id, d.doctor_id
    FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
         doctor d JOIN person dp ON d.person_id = dp.person_id
    WHERE pe.first_name = 'John' AND pe.last_name = 'Daniels'
        AND dp.last_name = 'Shah';

-- Mark Gray with Dr. Mitchell: Annual physical
INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_add(curdate(), interval 6 day), '08:30:00', 'Annual physical', pa.patient_id, d.doctor_id
    FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
         doctor d JOIN person dp ON d.person_id = dp.person_id
    WHERE pe.first_name = 'Mark' AND pe.last_name = 'Gray'
        AND dp.last_name = 'Mitchell';

-- Jane Daniels (1997) with Dr. Owen: Blood pressure check
INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_add(curdate(), interval 8 day), '11:45:00', 'Blood pressure check', pa.patient_id, d.doctor_id
    FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
         doctor d JOIN person dp ON d.person_id = dp.person_id
    WHERE pe.first_name = 'Jane' AND pe.date_of_birth = '1997-05-06'
        AND dp.last_name = 'Owen';

-- John Daniels with Dr. Reed: Acne consultation
INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_add(curdate(), interval 9 day), '14:30:00', 'Acne consultation', pa.patient_id, d.doctor_id
    FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
         doctor d JOIN person dp ON d.person_id = dp.person_id
    WHERE pe.first_name = 'John' AND pe.last_name = 'Daniels'
        AND dp.last_name = 'Reed';

-- Mark Gray with Dr. Shah: Recurring headaches
INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_add(curdate(), interval 10 day), '09:45:00', 'Recurring headaches', pa.patient_id, d.doctor_id
    FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
         doctor d JOIN person dp ON d.person_id = dp.person_id
    WHERE pe.first_name = 'Mark' AND pe.last_name = 'Gray'
        AND dp.last_name = 'Shah';

-- ----------------------------------
-- Past appointments for testing the past appointments list
-- ----------------------------------

-- Jane Daniels (2001) now has two past apointments
INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_sub(curdate(), interval 14 day), '10:00:00', 'Annual checkup', pa.patient_id, d.doctor_id
	FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
		 doctor d JOIN person dp ON d.person_id = dp.person_id
	WHERE pe.first_name = 'Jane' AND pe.date_of_birth = '2001-11-17'
		AND dp.last_name = 'Owen';

INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_sub(curdate(), interval 30 day), '13:30:00', 'Flu symptoms', pa.patient_id, d.doctor_id
	FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
		 doctor d JOIN person dp ON d.person_id = dp.person_id
	WHERE pe.first_name = 'Jane' AND pe.date_of_birth = '2001-11-17'
		AND dp.last_name = 'Daniels';
        
-- John Daniels with Dr. Reed: Skin irritation
INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_sub(curdate(), interval 12 day), '11:00:00', 'Skin irritation', pa.patient_id, d.doctor_id
    FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
         doctor d JOIN person dp ON d.person_id = dp.person_id
    WHERE pe.first_name = 'John' AND pe.last_name = 'Daniels'
        AND dp.last_name = 'Reed';

-- Mark Gray with Dr. Owen: Fatigue and dizziness
INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_sub(curdate(), interval 22 day), '13:15:00', 'Fatigue and dizziness', pa.patient_id, d.doctor_id
    FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
         doctor d JOIN person dp ON d.person_id = dp.person_id
    WHERE pe.first_name = 'Mark' AND pe.last_name = 'Gray'
        AND dp.last_name = 'Owen';

-- Jane Daniels (1997) with Dr. Mitchell: Sore throat
INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_sub(curdate(), interval 8 day), '10:30:00', 'Sore throat', pa.patient_id, d.doctor_id
    FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
         doctor d JOIN person dp ON d.person_id = dp.person_id
    WHERE pe.first_name = 'Jane' AND pe.date_of_birth = '1997-05-06'
        AND dp.last_name = 'Mitchell';

-- ----------------------------------
-- Patient Visits
-- ----------------------------------

-- Visit for Jane Daniels (2001) with Dr. Mitchell: editable, nothing recorded yet
INSERT INTO visit (visit_datetime, appointment_id)
SELECT timestamp(a.appointment_date, a.appointment_time), a.appointment_id
FROM appointment a
JOIN patient pa ON a.patient_id = pa.patient_id
JOIN person pe ON pa.person_id = pe.person_id
WHERE pe.first_name = 'Jane' AND pe.date_of_birth = '2001-11-17'
  AND a.appointment_date = date_sub(curdate(), interval 14 day);

INSERT INTO visit (visit_datetime, appointment_id, height, weight, systolic, diastolic,
                   body_temperature, pulse, symptoms, check_datetime,
                   initial_diagnosis, final_diagnosis, nurse_id, is_finalized)
SELECT timestamp(a.appointment_date, a.appointment_time), a.appointment_id,
       70, 180, 120, 80, 98.6, 72, 'Cough', timestamp(a.appointment_date, a.appointment_time) + interval 10 minute,
       'Possible dislocation', 'Broken Bone',
       (SELECT n.nurse_id FROM nurse n JOIN person p ON n.person_id = p.person_id
		WHERE p.last_name = 'Smith'),
       TRUE
FROM appointment a
JOIN patient pa ON a.patient_id = pa.patient_id
JOIN person pe ON pa.person_id = pe.person_id
WHERE pe.first_name = 'Jane' AND pe.date_of_birth = '2001-11-17'
  AND a.appointment_date = date_sub(curdate(), interval 30 day);

-- Visit for John Daniels with Dr. Mitchell: finalized, to test the read-only state
INSERT INTO visit (visit_datetime, appointment_id, height, weight, systolic, diastolic,
                   body_temperature, pulse, symptoms, check_datetime,
                   initial_diagnosis, final_diagnosis, nurse_id, is_finalized)
SELECT timestamp(a.appointment_date, a.appointment_time), a.appointment_id,
       70, 180, 120, 80, 98.6, 72, 'Cough', now(),
       'Possible cold', 'Common cold',
       (SELECT n.nurse_id FROM nurse n JOIN person p ON n.person_id = p.person_id
        WHERE p.last_name = 'Smith'),
       TRUE
FROM appointment a
JOIN patient pa ON a.patient_id = pa.patient_id
JOIN person pe ON pa.person_id = pe.person_id
WHERE pe.first_name = 'John' AND pe.last_name = 'Daniels'
  AND a.appointment_time = '09:30:00';
  
  
-- Visit for John Daniels with Dr. Reed: finalized, skin irritation
INSERT INTO visit (visit_datetime, appointment_id, height, weight, systolic, diastolic,
                   body_temperature, pulse, symptoms, check_datetime,
                   initial_diagnosis, final_diagnosis, nurse_id, is_finalized)
SELECT timestamp(a.appointment_date, a.appointment_time), a.appointment_id,
       71, 175, 118, 78, 98.4, 70, 'Redness and itching on arms',
       timestamp(a.appointment_date, a.appointment_time) + interval 10 minute,
       'Possible allergic reaction', 'Contact dermatitis',
       (SELECT n.nurse_id FROM nurse n JOIN person p ON n.person_id = p.person_id
        WHERE p.last_name = 'Lopez'),
       TRUE
FROM appointment a
JOIN patient pa ON a.patient_id = pa.patient_id
JOIN person pe ON pa.person_id = pe.person_id
JOIN doctor d ON a.doctor_id = d.doctor_id
JOIN person dp ON d.person_id = dp.person_id
WHERE pe.first_name = 'John' AND pe.last_name = 'Daniels'
  AND dp.last_name = 'Reed'
  AND a.appointment_date = date_sub(curdate(), interval 12 day);


-- Visit for Mark Gray with Dr. Owen: finalized, fatigue and dizziness
INSERT INTO visit (visit_datetime, appointment_id, height, weight, systolic, diastolic,
                   body_temperature, pulse, symptoms, check_datetime,
                   initial_diagnosis, final_diagnosis, nurse_id, is_finalized)
SELECT timestamp(a.appointment_date, a.appointment_time), a.appointment_id,
       69, 165, 110, 72, 98.2, 76, 'Fatigue, dizziness, and occasional headaches',
       timestamp(a.appointment_date, a.appointment_time) + interval 15 minute,
       'Possible anemia', 'Iron deficiency anemia',
       (SELECT n.nurse_id FROM nurse n JOIN person p ON n.person_id = p.person_id
        WHERE p.last_name = 'Wilson'),
       TRUE
FROM appointment a
JOIN patient pa ON a.patient_id = pa.patient_id
JOIN person pe ON pa.person_id = pe.person_id
JOIN doctor d ON a.doctor_id = d.doctor_id
JOIN person dp ON d.person_id = dp.person_id
WHERE pe.first_name = 'Mark' AND pe.last_name = 'Gray'
  AND dp.last_name = 'Owen'
  AND a.appointment_date = date_sub(curdate(), interval 22 day);


-- Visit for Jane Daniels (1997) with Dr. Mitchell: editable, not finalized
INSERT INTO visit (visit_datetime, appointment_id, height, weight, systolic, diastolic,
                   body_temperature, pulse, symptoms, check_datetime,
                   initial_diagnosis, final_diagnosis, nurse_id, is_finalized)
SELECT timestamp(a.appointment_date, a.appointment_time), a.appointment_id,
       65, 140, 116, 74, 99.1, 82, 'Sore throat and mild fever',
       timestamp(a.appointment_date, a.appointment_time) + interval 10 minute,
       'Possible strep throat', NULL,
       (SELECT n.nurse_id FROM nurse n JOIN person p ON n.person_id = p.person_id
        WHERE p.last_name = 'Green'),
       FALSE
FROM appointment a
JOIN patient pa ON a.patient_id = pa.patient_id
JOIN person pe ON pa.person_id = pe.person_id
JOIN doctor d ON a.doctor_id = d.doctor_id
JOIN person dp ON d.person_id = dp.person_id
WHERE pe.first_name = 'Jane' AND pe.date_of_birth = '1997-05-06'
  AND dp.last_name = 'Mitchell'
  AND a.appointment_date = date_sub(curdate(), interval 8 day);

-- ----------------------------------
-- Lab Tests
-- ----------------------------------

INSERT INTO lab_test 
VALUES ('BLD123', 'Complete Blood Count', 4000, 11000, 'µL'),
('BLD839', 'Platelet Count', 150000, 450000, 'µL'),
('BLD921', 'Hemoglobin', 12.0, 18.0, 'g/dL'),
('GLU450', 'Glucose', 70, 100, 'mg/dL'),
('FLU219', 'Flu test', NULL, NULL, 'N/a'),
('LDL100', 'Low Density Lipoproteins', '100', '160', 'mg/dL'),
('WBC220', 'White Blood Cell', 4000, 11000, 'µL'),
('HEPA22', 'Hepatitis A (HAV)', '0.80', '1.20', 'S/CO Index'),
('HEPB23', 'Hepatitis B (HBV)', '5', '10', 'mIU/mL'),
('HDL300', 'High Density Lipoproteins', 40, NULL, 'mg/dL'),
('A1C400', 'Hemoglobin A1c', NULL, 5.6, '%');

-- ----------------------------------
-- Old visits with ordered tests
-- ----------------------------------

SELECT v.visit_id, v.visit_datetime
INTO @oldVisitId, @oldVisitDateTime
FROM visit v
JOIN appointment a ON v.appointment_id = a.appointment_id
JOIN patient pa ON a.patient_id = pa.patient_id
JOIN person pe ON pa.person_id = pe.person_id
WHERE pe.first_name = 'Jane' AND pe.date_of_birth = '2001-11-17'
	AND a.appointment_date = date_sub(curdate(), interval 30 day);
    
INSERT INTO lab_order (order_datetime, visit_id)
VALUES (@oldVisitDatetime, @oldVisitId);
SET @orderId = last_insert_id();

INSERT INTO ordered_test (lab_order_id, test_code, datetime_performed, test_result, is_abnormal)
VALUES (@orderId, 'BLD123', @oldVisitDatetime + interval 1 day, 6500, false),
	(@orderId, 'BLD921', @oldVisitDatetime + interval 1 day, 10.5, true),
    (@orderId, 'BLD839', @oldVisitDatetime + interval 1 day, 200000, false),
    (@orderId, 'GLU450', @oldVisitDatetime + interval 1 day, 85, false),
    (@orderId, 'FLU219', @oldVisitDatetime + interval 1 day, NULL, false);


SELECT v.visit_id, v.visit_datetime
INTO @recentVisitId, @recentVisitDatetime
FROM visit v
JOIN appointment a ON v.appointment_id = a.appointment_id
JOIN patient pa ON a.patient_id = pa.patient_id
JOIN person pe ON pa.person_id = pe.person_id
WHERE pe.first_name = 'Jane' AND pe.date_of_birth = '2001-11-17'
  AND a.appointment_date = date_sub(curdate(), interval 14 day);

INSERT INTO lab_order (order_datetime, visit_id)
VALUES (@recentVisitDatetime, @recentVisitId);
SET @orderId = last_insert_id();

INSERT INTO ordered_test (lab_order_id, test_code, datetime_performed, test_result, is_abnormal)
VALUES (@orderId, 'BLD123', @recentVisitDatetime + interval 1 day, 12000, true),
	(@orderId, 'BLD921', @recentVisitDatetime + interval 1 day, 14.0, false),
	(@orderId, 'BLD839', @recentVisitDatetime + interval 1 day, 250000, false);


INSERT INTO appointment (appointment_date, appointment_time, reason, patient_id, doctor_id)
SELECT date_sub(curdate(), interval 21 day), '10:00:00', 'Fatigue', pa.patient_id, d.doctor_id
	FROM patient pa JOIN person pe ON pa.person_id = pe.person_id,
		 doctor d JOIN person dp ON d.person_id = dp.person_id
	WHERE pe.first_name = 'Mark' AND pe.last_name = 'Gray'
		AND dp.last_name = 'Owen';

INSERT INTO visit (visit_datetime, appointment_id)
SELECT timestamp(a.appointment_date, a.appointment_time), a.appointment_id
FROM appointment a
JOIN patient pa ON a.patient_id = pa.patient_id
JOIN person pe ON pa.person_id = pe.person_id
WHERE pe.first_name = 'Mark' AND pe.last_name = 'Gray'
  AND a.appointment_date = date_sub(curdate(), interval 21 day);

SET @markVisitId = last_insert_id();

INSERT INTO lab_order (order_datetime, visit_id)
SELECT visit_datetime, visit_id
FROM visit
WHERE visit_id = @markVisitId;
SET @orderId = last_insert_id();

INSERT INTO ordered_test (lab_order_id, test_code, datetime_performed, test_result, is_abnormal)
SELECT @orderId, 'BLD123', visit_datetime + interval 1 day, 7000, false
FROM visit WHERE visit_id = @markVisitId
UNION ALL
SELECT @orderId, 'BLD921', NULL, NULL, false
FROM visit WHERE visit_id = @markVisitId;

-- ----------------------------------
-- John Daniels: Skin irritation with Dr. Reed
-- ----------------------------------

SELECT v.visit_id, v.visit_datetime
INTO @johnVisitId, @johnVisitDatetime
FROM visit v
JOIN appointment a ON v.appointment_id = a.appointment_id
JOIN patient pa ON a.patient_id = pa.patient_id
JOIN person pe ON pa.person_id = pe.person_id
WHERE pe.first_name = 'John' AND pe.last_name = 'Daniels'
    AND a.appointment_date = date_sub(curdate(), interval 12 day);

INSERT INTO lab_order (order_datetime, visit_id)
VALUES (@johnVisitDatetime, @johnVisitId);
SET @orderId = last_insert_id();

INSERT INTO ordered_test (lab_order_id, test_code, datetime_performed, test_result, is_abnormal)
VALUES (@orderId, 'BLD123', @johnVisitDatetime + interval 1 day, '7500', false),
       (@orderId, 'BLD921', @johnVisitDatetime + interval 1 day, '15.0', false),
       (@orderId, 'GLU450', @johnVisitDatetime + interval 1 day, '110', true);


-- ----------------------------------
-- Mark Gray: Fatigue and dizziness with Dr. Owen
-- ----------------------------------

SELECT v.visit_id, v.visit_datetime
INTO @markOldVisitId, @markOldVisitDatetime
FROM visit v
JOIN appointment a ON v.appointment_id = a.appointment_id
JOIN patient pa ON a.patient_id = pa.patient_id
JOIN person pe ON pa.person_id = pe.person_id
WHERE pe.first_name = 'Mark' AND pe.last_name = 'Gray'
    AND a.appointment_date = date_sub(curdate(), interval 22 day);

INSERT INTO lab_order (order_datetime, visit_id)
VALUES (@markOldVisitDatetime, @markOldVisitId);
SET @orderId = last_insert_id();

INSERT INTO ordered_test (lab_order_id, test_code, datetime_performed, test_result, is_abnormal)
VALUES (@orderId, 'BLD123', @markOldVisitDatetime + interval 1 day, '6800', false),
       (@orderId, 'BLD921', @markOldVisitDatetime + interval 1 day, '10.2', true),
       (@orderId, 'BLD839', @markOldVisitDatetime + interval 1 day, '210000', false),
       (@orderId, 'GLU450', NULL, NULL, false);