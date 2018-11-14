CREATE TABLE Seller 
(
   	SellerID int IDENTITY(1,1) NOT NULL,
    Name nvarchar(50) NOT NULL,
    CONSTRAINT PK_Seller PRIMARY KEY (SellerID)
);

INSERT INTO Seller (Name)
    VALUES
    ('Gayle Hardy'),
    ('Lyle Banks'),
    ('Pearl Greene');

CREATE TABLE Buyer
(
   	BuyerID int IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
    CONSTRAINT PK_Buyer PRIMARY KEY (BuyerID)
);

INSERT INTO Buyer (Name)
    VALUES
    ('Jane Stone'),
    ('Tom McMasters'),
    ('Otto Vanderwall');

CREATE TABLE Item 
(
	ItemID int IDENTITY(1,1) NOT NULL,
	Name nvarchar(max) NOT NULL,
	Description nvarchar(max) NOT NULL,
	SellerID int NOT NULL,
	CONSTRAINT PK_Item PRIMARY KEY (ItemID),
	CONSTRAINT FK_Item_Seller FOREIGN KEY (SellerID) REFERENCES Seller(SellerID)
);

INSERT INTO Item
           (Name
           ,Description
           ,SellerID)
     VALUES
('Abraham Lincoln Hammer'    ,'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 3),
('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927', 1),
('Bob Dylan Love Poems'      ,'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 2);

	
CREATE TABLE Bid 
(
    BidID int IDENTITY(1,1) NOT NULL,
    Price nvarchar(max) NOT NULL,
    Timestamp datetime NOT NULL,
    ItemID int NOT NULL,
    BuyerID int NOT NULL,
    CONSTRAINT PK_Bid PRIMARY KEY (BidID),
    CONSTRAINT FK_Bid_Item FOREIGN KEY (ItemID) REFERENCES Item(ItemID),
    CONSTRAINT FK_Bid_Buyer FOREIGN KEY (BuyerID) REFERENCES Buyer(BuyerID)
);
	
INSERT INTO Bid
           (Price
           ,Timestamp
           ,ItemID
           ,BuyerID)
     VALUES
(250000, '12/04/2017 09:04:22', 1, 3),
(95000 , '12/04/2017 08:44:03', 3, 1); 