CREATE DATABASE tasksmanager;
WITH 
ENCODING = 'UTF8';

CREATE TABLE tasks(
  id UUID PRIMARY KEY,
  name VARCHAR(255)
);

CREATE USER db_iam_user; 
GRANT rds_iam TO db_iam_user;
GRANT postgres TO db_iam_user;