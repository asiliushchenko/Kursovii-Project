-- Роль менеджера
CREATE USER 'manager'@'localhost' IDENTIFIED BY 'manager123';
GRANT ALL PRIVILEGES ON cinema_db.* TO 'manager'@'localhost';

-- Роль відвідувача
CREATE USER 'visitor'@'localhost' IDENTIFIED BY 'visitor123';

GRANT SELECT ON cinema_db.Film TO 'visitor'@'localhost';
GRANT SELECT ON cinema_db.Session TO 'visitor'@'localhost';
GRANT SELECT ON cinema_db.Hall TO 'visitor'@'localhost';

-- Роль касира
CREATE USER 'cashier'@'localhost' IDENTIFIED BY 'cashier123';

GRANT SELECT ON cinema_db.Film TO 'cashier'@'localhost';
GRANT SELECT ON cinema_db.Session TO 'cashier'@'localhost';
GRANT SELECT ON cinema_db.Hall TO 'cashier'@'localhost';

GRANT INSERT, UPDATE ON cinema_db.Ticket TO 'cashier'@'localhost';