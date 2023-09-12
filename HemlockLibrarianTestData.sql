-- Insert dummy data into Users table
INSERT INTO Users (UserID, UserName, Email, Phone, PIN, Balance)
VALUES
    (1, 'John Doe', 'johndoe@example.com', '1234567890', '1234', 0),
    (2, 'Jane Smith', 'janesmith@example.com', '9876543210', '5678', 10.50),
    (3, 'Michael Phelps', 'michaelphelps@example.com', '5551234567', '4321', 25.00),
    (4, 'Katie Ledecky', 'katieledecky@example.com', '5559876543', '8765', 12.75),
    (5, 'Mark Spitz', 'markspitz@example.com', '5555555555', '2468', 5.50),
    (6, 'Erika Lust', 'erikalust@example.com', '5556789012', '1357', 15.00),
    (7, 'Nina Hartley', 'ninahartley@example.com', '5552345678', '9753', 8.25),
    (8, 'Greg LeMond', 'greglemond@example.com', '5558765432', '3691', 18.50),
    (9, 'Eddy Merckx', 'eddymerckx@example.com', '5554321098', '8642', 22.75),
    (10, 'Beryl Burton', 'berylburton@example.com', '5553210987', '1592', 9.50);

-- Insert dummy data into Branches table
INSERT INTO Branches (BranchID, BranchName, PhoneNumber, Address, City, State, PostalCode, Country)
VALUES
    (1, 'Butterfly Fitness Center', '1234567890', '123 Main St', 'City', 'State', '12345', 'Country'),
    (2, 'Freestyle Sports Club', '9876543210', '456 Second St', 'City', 'State', '54321', 'Country'),
    (3, 'Cycling Love Studio', '5551234567', '789 Third St', 'City', 'State', '98765', 'Country'),
    (4, 'Backstroke Performance Center', '5559876543', '321 Fourth St', 'City', 'State', '56789', 'Country'),
    (5, 'Breaststroke Aquatic Club', '5555555555', '555 Fifth St', 'City', 'State', '55555', 'Country'),
    (6, 'Erotic Eddy''s Bike Shop', '5556789012', '678 Sixth St', 'City', 'State', '67890', 'Country');

-- Insert dummy data into Books table
INSERT INTO Books (BookID, Title, Author, ISBN, PublicationYear, DeweyClassification, BookDescription)
VALUES
    (1, 'The Art of the Butterfly Stroke', 'Swim Master', '1234567890', 2020, 123.456, 'Master the graceful technique of the butterfly stroke with this comprehensive guide.'),
    (2, 'Freestyle Speed Secrets', 'Swim Pro', '0987654321', 2018, 789.012, 'Unlock the secrets to faster freestyle swimming and improve your performance in the pool.'),
    (3, 'Cycling Climbing Techniques', 'Bike Guru', '3456789012', 2015, 234.567, 'Learn the strategies and techniques to conquer challenging climbs on your road bike.'),
    (4, 'The Erotic Swim Coach', 'Seductive Author', '2109876543', 2010, 901.234, 'Experience a scintillating tale of desire and forbidden love set in the world of competitive swimming.'),
    (5, 'Sensual Cycling Adventures', 'Erika Lust', '5678901234', 2022, 901.234, 'Embark on a journey of passion and pleasure with this collection of cycling-themed erotic stories.'),
    (6, 'The Cycling Seductress', 'Passionate Author', '4321098765', 2005, 234.567, 'Indulge in the steamy encounters and captivating allure of a mysterious cyclist.');

-- Insert dummy data into Items table
INSERT INTO Items (ItemID, BookID, BranchID, CheckoutStatus, CurrentBranchID)
VALUES
    (1, 1, 1, 0, 1),
    (2, 2, 2, 0, 2),
    (3, 3, 3, 0, 3),
    (4, 4, 4, 0, 4),
    (5, 5, 5, 0, 5),
    (6, 6, 6, 0, 6);

-- Insert dummy data into Holds table
INSERT INTO Holds (HoldID, UserID, BookID, HoldDate)
VALUES
    (1, 1, 1, GETDATE()),
    (2, 2, 2, GETDATE()),
    (3, 3, 3, GETDATE()),
    (4, 4, 4, GETDATE()),
    (5, 5, 5, GETDATE()),
    (6, 6, 6, GETDATE());

-- Insert dummy data into Transactions table
INSERT INTO Transactions (TransactionID, UserID, ItemID, CheckoutDate, ReturnDate, Fine)
VALUES
    (1, 1, 1, GETDATE(), GETDATE(), 0),
    (2, 2, 2, GETDATE(), GETDATE(), 0),
    (3, 3, 3, GETDATE(), GETDATE(), 0),
    (4, 4, 4, GETDATE(), GETDATE(), 0),
    (5, 5, 5, GETDATE(), GETDATE(), 0),
    (6, 6, 6, GETDATE(), GETDATE(), 0);
