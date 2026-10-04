use sc3230f26_g3;

DROP TABLE IF EXISTS `ordered_test`;
DROP TABLE IF EXISTS `lab_order`;
DROP TABLE IF EXISTS `lab_test`;
DROP TABLE IF EXISTS `visit`;
DROP TABLE IF EXISTS `appointment`;
DROP TABLE IF EXISTS `doctor_specialty`;
DROP TABLE IF EXISTS `specialty`;
DROP TABLE IF EXISTS `user_account`;
DROP TABLE IF EXISTS `administrator`;
DROP TABLE IF EXISTS `nurse`;
DROP TABLE IF EXISTS `patient`;
DROP TABLE IF EXISTS `doctor`;
DROP TABLE IF EXISTS `person`;

CREATE TABLE `person` (
	person_id int auto_increment primary key,
    first_name varchar(50) not null,
    last_name varchar(50) not null,
    date_of_birth date not null,
    street_address varchar(100),
    city varchar(50),
    state varchar(50),
    zip_code varchar(10),
    phone_number varchar(20)
);

CREATE TABLE `doctor` (
	doctor_id int auto_increment primary key,
    person_id int not null unique,
    foreign key (person_id) references `person`(person_id)
    );
    
CREATE TABLE `nurse` (
	nurse_id int auto_increment primary key,
    person_id int not null unique,
    foreign key (person_id) references `person`(person_id)
    );
    
CREATE TABLE `patient` (
    patient_id int auto_increment primary key,
    is_active boolean not null default true,
    person_id  int not null unique,
	foreign key (person_id) references `person`(person_id)
);

CREATE TABLE `administrator` (
    administrator_id int auto_increment primary key,
    person_id int not null unique,
	foreign key (person_id) references `person`(person_id)
);

CREATE TABLE `user_account` (
    account_id int auto_increment primary key,
    username varchar(50) not null unique,
    password varchar(255) not null,
    account_role varchar(30) not null,
    person_id int not null,

    foreign key (person_id) references `person`(person_id)
);

CREATE TABLE `specialty` (
    specialty_id int auto_increment primary key,
    specialty_name varchar(100) not null unique
);

CREATE TABLE `doctor_specialty` (
    doctor_id int not null,
    specialty_id int not null,
    primary key (doctor_id, specialty_id),
    foreign key (doctor_id) references `doctor`(doctor_id),
    foreign key (specialty_id) references `specialty`(specialty_id)
);

CREATE TABLE `appointment` (
    appointment_id int auto_increment primary key,
    appointment_date date not null,
    appointment_time time not null,
    reason varchar(255),
    patient_id int not null,
    doctor_id int not null,
    foreign key (patient_id) references `patient`(patient_id),
	foreign key (doctor_id) references `doctor`(doctor_id)
);

CREATE TABLE `visit` (
    visit_id int auto_increment primary key,
    visit_datetime datetime not null,
    appointment_id int not null unique,
    height decimal(6,2),
    weight decimal(6,2),
    systolic int,
    diastolic int,
    body_temperature decimal(4,1),
    pulse int,
    symptoms text,
    check_datetime datetime,
    initial_diagnosis text,
    final_diagnosis text,
    nurse_id int,
    is_finalized boolean not null default false,
    foreign key (appointment_id) references `appointment`(appointment_id),
	foreign key (nurse_id) references `nurse`(nurse_id)
);

CREATE TABLE `lab_test` (
    test_code varchar(20) primary key,
    test_name varchar(100) not null unique,
    low_value decimal(10,2),
    high_value decimal(10,2),
    unit_name varchar(30)
);

CREATE TABLE `lab_order` (
    lab_order_id int auto_increment primary key,
    order_datetime datetime not null,
    visit_id int not null,
	foreign key (visit_id) references `visit`(visit_id)
);

CREATE TABLE `ordered_test` (
    lab_order_id int not null,
    test_code varchar(20) not null,
    datetime_performed datetime,
    test_result decimal(10,2),
    is_abnormal boolean not null default false,
    primary key (lab_order_id, test_code),
    foreign key (lab_order_id) references `lab_order`(lab_order_id),
    foreign key (test_code) references `lab_test`(test_code)
);