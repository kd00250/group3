-- Test data for the heathcare project. Run after CS3230_InitialDBCreationScript.sql on empty tables.
-- To restart, rerun CS3230_InitialDBCreationScript.sql first.

-- ----------------------------------
-- Users for login/logout testing
-- ----------------------------------

-- Nurse: Emily Smith (username: esmith, password: nurse123)
INSERT INTO person (first_name, last_name, date_of_birth, street_address, city, state, zip_code, phone_number)
VALUES ('Emily', 'Smith', '1995-04-14', '13 Birch St', 'Carrollton', 'GA', '30117', '770-555-0123');
SET @personId = last_insert_id();
INSERT INTO nurse (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('esmith', 'nurse123', 'nurse', @personId);

-- Nurse: David Rogers (username: drogers, password: nurse456)
INSERT INTO person (first_name, last_name, date_of_birth, street_address, city, state, zip_code, phone_number)
VALUES ('David', 'Rogers', '1992-07-22', '24 Willow Dr', 'Newnan', 'GA', '30263', '770-555-4567');
SET @personId = last_insert_id();
INSERT INTO nurse (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('drogers', 'nurse456', 'nurse', @personId);

-- Admin Donna Grace (username: dgrace, password: admin123)
INSERT INTO person (first_name, last_name, date_of_birth, street_address, city, state, zip_code, phone_number)
VALUES ('Donna', 'Grace', '1985-12-04', '5 Spruce Ct', 'Carrollton', 'GA', '30116', '770-555-7421');
SET @personId = last_insert_id();
INSERT INTO administrator (person_id)
VALUES (@personId);
INSERT INTO user_account (username, password, account_role, person_id)
VALUES ('dgrace', 'admin123', 'administrator', @personId);


-- ----------------------------------
-- Patients for search testing
-- ----------------------------------

-- Jane Daniels born 2001
INSERT INTO person (first_name, last_name, date_of_birth, street_address, city, state, zip_code, phone_number)
VALUES ('Jane', 'Daniels', '2001-11-17', '123 Maple St', 'Carrollton', 'GA', '30117', '770-555-1313');
INSERT INTO patient (person_id)
VALUES (last_insert_id());

-- Jane Daniels born 1997, duplicate name, different birthday
INSERT INTO person (first_name, last_name, date_of_birth, street_address, city, state, zip_code, phone_number)
VALUES ('Jane', 'Daniels', '1997-05-06', '12 Oak Ave', 'Newnan', 'GA', '30263', '770-555-0987');
INSERT INTO patient (person_id)
VALUES (last_insert_id());

-- John Daniels, duplicate last name, different first name
INSERT INTO person (first_name, last_name, date_of_birth, street_address, city, state, zip_code, phone_number)
VALUES ('John', 'Daniels', '1994-10-28', '9 Pine Rd', 'Carrollton', 'GA', '30116', '770-555-2424');
INSERT INTO patient (person_id)
VALUES (last_insert_id());

-- Mark Gray, duplicate birthday
INSERT INTO person (first_name, last_name, date_of_birth, street_address, city, state, zip_code, phone_number)
VALUES ('Mark', 'Gray', '2001-11-17', '10 Kindelwood Dr', 'Newnan', 'GA', '30263', '770-555-2745');
INSERT INTO patient (person_id)
VALUES (last_insert_id());

-- Robert Lee, inactive patient
INSERT INTO person (first_name, last_name, date_of_birth, street_address, city, state, zip_code, phone_number)
VALUES ('Robert', 'Lee', '2003-12-17', '12 Mill St', 'Carrollton', 'GA', '30116', '770-555-2763');
INSERT INTO patient (person_id, is_active)
VALUES (last_insert_id(), false);