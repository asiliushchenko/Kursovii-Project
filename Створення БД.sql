CREATE DATABASE cinema_db;

USE cinema_db;

CREATE TABLE Film (
    film_id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(200) NOT NULL,
    genre VARCHAR(100),
    duration INT,
    age_rating VARCHAR(10),
    description TEXT
);

CREATE TABLE Hall (
    hall_id INT AUTO_INCREMENT PRIMARY KEY,
    hall_name VARCHAR(50) NOT NULL,
    line INT NOT NULL,
    seats_per_row INT NOT NULL
);

CREATE TABLE Session (
    session_id INT AUTO_INCREMENT PRIMARY KEY,
    film_id INT NOT NULL,
    hall_id INT NOT NULL,
    start_time DATETIME NOT NULL,
    price DECIMAL(10,2) NOT NULL,
    
    FOREIGN KEY (film_id) REFERENCES Film(film_id),
    FOREIGN KEY (hall_id) REFERENCES Hall(hall_id)
);

CREATE TABLE Ticket (
    ticket_id INT AUTO_INCREMENT PRIMARY KEY,
    session_id INT NOT NULL,
    seat_row INT NOT NULL,
    seat_number INT NOT NULL,
    status ENUM('Вільне', 'Заброньовано') DEFAULT 'Вільне',
    customer_name VARCHAR(200),

    FOREIGN KEY (session_id) REFERENCES Session(session_id)
);

CREATE TABLE Users (
    user_id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL,
    role ENUM('manager', 'cashier', 'viewer') NOT NULL
);
