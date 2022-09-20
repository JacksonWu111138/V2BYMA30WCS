------------Sno_Max -------------
INSERT INTO Sno_Max (Sno_Type,Month_Flag,Init_Sno,Max_Sno,Sno_Len) 
VALUES 
('CMDSNO', 'Y', 1, 19997, 5),
('BATCH', 'N', 1, 29997, 5),
('CMDSUO', 'N', 20001, 29997, 5);

INSERT INTO UnitModeDef (StockerID, In_enable) VALUES
('1', 'Y'),
('2', 'Y'),
('3', 'Y'),
('4', 'Y');

insert into Teach_Loc (DeviceID,Loc) VALUES
('1','0200303'),
('2','0200303'),
('3','0200303');

--STK 1 (PCBA)
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('1', 'M1-01', 3, 1, 1, ' ', 2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('1', 'M1-06', 3, 2, 6, ' ', 1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('1', 'LeftFork', 4, 1, 1, ' ', 0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('1', 'Shelf', 0, 1, 1, ' ', 0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('1', 'Teach', 0, 2, 2, ' ', 0);


--STK 2 (PCBA)
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('2', 'M1-11', 3, 1, 11, ' ', 2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('2', 'M1-16', 3, 2, 16, ' ', 1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('2', 'LeftFork', 4, 1, 1, ' ', 0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('2', 'Shelf', 0, 1, 1, ' ', 0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('2', 'Teach', 0, 2, 2, ' ', 0);


--STK 3 (箱式倉1)
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('3', 'B1-001', 3, 1, 1, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('3', 'B1-004', 3, 2, 4, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('3', 'B1-007', 3, 3, 7, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('3', 'B1-010', 3, 4, 10, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('3', 'B1-081', 3, 5, 81, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('3', 'B1-084', 3, 6, 84, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('3', 'B1-087', 3, 7, 87, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('3', 'B1-090', 3, 8, 90, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('3', 'LeftFork', 4, 1, 1, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('3', 'Shelf', 0, 1, 1, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('3', 'Teach', 0, 2, 2, ' ',0);


--STK 4 (箱式倉2)
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('4', 'B1-013', 3, 1, 13, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('4', 'B1-016', 3, 2, 16, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('4', 'B1-019', 3, 3, 19, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('4', 'B1-022', 3, 4, 22, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('4', 'B1-093', 3, 5, 93, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('4', 'B1-096', 3, 6, 96, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('4', 'B1-099', 3, 7, 99, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('4', 'B1-102', 3, 8, 102, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('4', 'LeftFork', 4, 1, 1, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('4', 'Shelf', 0, 1, 1, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('4', 'Teach', 0, 2, 2, ' ',0);


--STK 5 (箱式倉3)
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('5', 'B1-025', 3, 1, 25, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('5', 'B1-028', 3, 2, 28, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('5', 'B1-031', 3, 3, 31, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('5', 'B1-034', 3, 4, 34, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('5', 'B1-105', 3, 5, 105, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('5', 'B1-108', 3, 6, 108, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('5', 'B1-111', 3, 7, 111, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('5', 'B1-114', 3, 8, 114, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('5', 'LeftFork', 4, 1, 1, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('5', 'Shelf', 0, 1, 1, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('5', 'Teach', 0, 2, 2, ' ',0);


--AGV (3F)
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('63', 'A1-04', 3, 1, 4, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('63', 'A1-08', 3, 2, 8, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('63', 'A1-12', 3, 3, 12, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('63', 'LO4-04', 3, 4, 4, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('63', 'A1-01', 3, 5, 1, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('63', 'A1-05', 3, 6, 5, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('63', 'A1-09', 3, 7, 9, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('63', 'LO4-01', 3, 8, 1, ' ',2);


--AGV (5F)
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('65', 'A2-04', 3, 1, 4, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('65', 'A2-08', 3, 2, 8, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('65', 'A2-12', 3, 3, 12, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('65', 'A2-16', 3, 4, 16, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('65', 'A2-20', 3, 5, 20, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('65', 'LO5-04', 3, 6, 4, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('65', 'A2-01', 3, 7, 1, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('65', 'A2-05', 3, 8, 5, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('65', 'A2-09', 3, 9, 9, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('65', 'A2-13', 3, 10, 13, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('65', 'A2-17', 3, 11, 17, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('65', 'LO5-01', 3, 12, 1, ' ',2);


--AGV (6F)
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('66', 'A3-04', 3, 1, 4, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('66', 'A3-08', 3, 2, 8, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('66', 'A3-12', 3, 3, 12, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('66', 'A3-16', 3, 4, 16, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('66', 'A3-20', 3, 5, 20, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('66', 'LO6-04', 3, 6, 4, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('66', 'A3-01', 3, 7, 1, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('66', 'A3-05', 3, 8, 5, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('66', 'A3-09', 3, 9, 9, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('66', 'A3-13', 3, 10, 13, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('66', 'A3-17', 3, 11, 17, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('66', 'LO6-01', 3, 12, 1, ' ',2);


--AGV (8F)
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'M1-05', 3, 1, 5, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'M1-15', 3, 2, 15, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'A4-04', 3, 3, 4, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'A4-08', 3, 4, 8, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'A4-12', 3, 5, 12, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'A4-16', 3, 6, 16, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'A4-20', 3, 7, 20, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'E1-08', 3, 8, 8, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'E2-35', 3, 9, 35, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'E2-36', 3, 10, 36, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'E2-37', 3, 11, 37, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'E2-38', 3, 12, 38, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'E2-39', 3, 13, 39, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'E2-44', 3, 14, 44, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'B1-070', 3, 15, 70, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'B1-074', 3, 16, 74, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'B1-078', 3, 17, 78, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'LO2-04', 3, 18, 4, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'LO3-01', 3, 19, 1, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'M1-10', 3, 20, 10, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'M1-20', 3, 21, 20, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'A4-01', 3, 22, 1, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'A4-05', 3, 23, 5, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'A4-09', 3, 24, 9, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'A4-13', 3, 25, 13, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'A4-17', 3, 26, 17, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'E1-01', 3, 27, 1, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'B1-071', 3, 28, 71, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'B1-075', 3, 29, 75, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'B1-079', 3, 30, 79, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'LO2-01', 3, 31, 1, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'LO3-04', 3, 32, 4, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-49', 3, 33, 49, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-50', 3, 34, 50, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-01', 3, 35, 1, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-07', 3, 36, 7, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-13', 3, 37, 13, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-25', 3, 38, 25, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-31', 3, 39, 31, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-40', 3, 40, 40, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-44', 3, 41, 44, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-48', 3, 42, 48, ' ',1);
--insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-52', 3, 43, 52, ' ',1);
--insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-56', 3, 44, 56, ' ',1);
--insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-60', 3, 45, 60, ' ',1);
--insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-64', 3, 46, 64, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-37', 3, 47, 37, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-41', 3, 48, 41, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S1-45', 3, 49, 45, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S2-49', 3, 50, 49, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S2-01', 3, 51, 1, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S2-07', 3, 52, 7, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S2-13', 3, 53, 13, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S2-25', 3, 54, 25, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S2-31', 3, 55, 31, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S3-49', 3, 56, 49, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S3-01', 3, 57, 1, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S3-07', 3, 58, 7, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S3-13', 3, 59, 13, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S3-19', 3, 60, 19, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S3-25', 3, 61, 25, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S3-31', 3, 62, 31, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S3-37', 3, 63, 37, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S3-41', 3, 64, 41, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S3-44', 3, 65, 44, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S3-45', 3, 66, 45, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S3-40', 3, 67, 40, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S3-48', 3, 68, 48, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S4-49', 3, 69, 49, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S4-50', 3, 70, 50, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S4-01', 3, 71, 1, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S4-07', 3, 72, 7, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S4-13', 3, 73, 13, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S4-19', 3, 74, 19, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S4-25', 3, 75, 25, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S5-49', 3, 76, 49, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S5-01', 3, 77, 1, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S5-07', 3, 78, 7, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S5-37', 3, 79, 37, ' ',2);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S5-40', 3, 80, 40, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S6-01', 3, 81, 1, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('68', 'S6-07', 3, 82, 7, ' ',0);

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'B1-070', '3', 'B1-007', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'B1-074', '3', 'B1-007', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'B1-078', '3', 'B1-007', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'B1-070', '4', 'B1-019', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'B1-074', '4', 'B1-019', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'B1-078', '4', 'B1-019', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'B1-070', '5', 'B1-031', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'B1-074', '5', 'B1-031', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'B1-078', '5', 'B1-031', ' ');


--電子料塔
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('7', 'Shelf', 0, 1, 1, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('7', 'E1-04', 3, 1, 4, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('7', 'E1-10', 3, 2, 10, ' ',1);

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('7', 'Shelf', '68', 'E1-08', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('7', 'E1-04', '68', 'E1-08', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'E1-01', '7', 'E1-04', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('7', 'Shelf', '68', 'E2-35', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('7', 'Shelf', '68', 'E2-36', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('7', 'Shelf', '68', 'E2-37', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('7', 'Shelf', '68', 'E2-38', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('7', 'Shelf', '68', 'E2-39', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('7', 'Shelf', '68', 'E2-44', ' ');


--E04電梯
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('E04', 'LO1-02', 3, 1, 2, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('E04', 'LO1-07', 3, 2, 7, ' ',1);

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('E04', 'LO1-02', '68', 'LO2-04', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'LO2-01', 'E04', 'LO1-07', ' ');


--Box1 箱式倉1
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Box1', 'B1-037', 3, 1, 37, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Box1', 'B1-041', 3, 2, 41, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Box1', 'B1-045', 3, 3, 45, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Box1', 'B1-054', 3, 4, 54, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Box1', 'B1-062', 3, 5, 62, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Box1', 'B1-067', 3, 6, 67, ' ',0);

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-037', '3', 'B1-007', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-037', '4', 'B1-019', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-037', '5', 'B1-031', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-041', '3', 'B1-007', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-041', '4', 'B1-019', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-041', '5', 'B1-031', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-045', '3', 'B1-007', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-045', '4', 'B1-019', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-045', '5', 'B1-031', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-054', '3', 'B1-007', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-054', '4', 'B1-019', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-054', '5', 'B1-031', ' ');

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-062', '68', 'B1-071', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-062', '68', 'B1-075', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-062', '68', 'B1-079', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-067', '68', 'B1-071', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-067', '68', 'B1-075', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-067', '68', 'B1-079', ' ');

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-062', '3', 'B1-007', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-067', '3', 'B1-007', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-062', '4', 'B1-019', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-067', '4', 'B1-019', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-062', '5', 'B1-031', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box1', 'B1-067', '5', 'B1-031', ' ');

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('3', 'B1-001', 'Box1', 'B1-062', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('3', 'B1-004', 'Box1', 'B1-062', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('3', 'B1-001', 'Box1', 'B1-067', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('3', 'B1-004', 'Box1', 'B1-067', ' ');

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('4', 'B1-013', 'Box1', 'B1-062', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('4', 'B1-016', 'Box1', 'B1-062', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('4', 'B1-013', 'Box1', 'B1-067', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('4', 'B1-016', 'Box1', 'B1-067', ' ');

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('5', 'B1-025', 'Box1', 'B1-062', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('5', 'B1-028', 'Box1', 'B1-062', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('5', 'B1-025', 'Box1', 'B1-067', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('5', 'B1-028', 'Box1', 'B1-067', ' ');


--Box2 箱式倉2
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Box2', 'B1-117', 3, 1, 117, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Box2', 'B1-121', 3, 2, 121, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Box2', 'B1-125', 3, 3, 125, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Box2', 'B1-134', 3, 4, 134, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Box2', 'B1-142', 3, 5, 142, ' ',0);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Box2', 'B1-147', 3, 6, 147, ' ',0);

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-117', '3', 'B1-087', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-117', '4', 'B1-099', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-117', '5', 'B1-111', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-121', '3', 'B1-087', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-121', '4', 'B1-099', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-121', '5', 'B1-111', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-125', '3', 'B1-087', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-125', '4', 'B1-099', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-125', '5', 'B1-111', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-134', '3', 'B1-087', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-134', '4', 'B1-099', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-134', '5', 'B1-111', ' ');

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-142', '3', 'B1-087', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-147', '3', 'B1-087', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-142', '4', 'B1-099', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-147', '4', 'B1-099', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-142', '5', 'B1-111', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Box2', 'B1-147', '5', 'B1-111', ' ');

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('3', 'B1-081', 'Box2', 'B1-142', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('3', 'B1-084', 'Box2', 'B1-142', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('3', 'B1-081', 'Box2', 'B1-147', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('3', 'B1-084', 'Box2', 'B1-147', ' ');

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('4', 'B1-093', 'Box2', 'B1-142', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('4', 'B1-096', 'Box2', 'B1-142', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('4', 'B1-093', 'Box2', 'B1-147', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('4', 'B1-096', 'Box2', 'B1-147', ' ');

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('5', 'B1-105', 'Box2', 'B1-142', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('5', 'B1-108', 'Box2', 'B1-142', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('5', 'B1-105', 'Box2', 'B1-147', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('5', 'B1-108', 'Box2', 'B1-147', ' ');


--SMT3C (3F產線)
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT3C', 'A1-02', 3, 1, 2, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT3C', 'A1-03', 3, 2, 3, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT3C', 'A1-06', 3, 3, 6, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT3C', 'A1-07', 3, 4, 7, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT3C', 'A1-10', 3, 5, 10, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT3C', 'A1-11', 3, 6, 11, ' ',1);

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('63', 'A1-01', 'SMT3C', 'A1-02', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('63', 'A1-05', 'SMT3C', 'A1-06', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('63', 'A1-09', 'SMT3C', 'A1-10', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMT3C', 'A1-03', '63', 'A1-04', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMT3C', 'A1-07', '63', 'A1-08', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMT3C', 'A1-11', '63', 'A1-12', ' ');

--SMT5C (5F產線)
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT5C', 'A2-02', 3, 1, 2, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT5C', 'A2-03', 3, 2, 3, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT5C', 'A2-06', 3, 3, 6, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT5C', 'A2-07', 3, 4, 7, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT5C', 'A2-10', 3, 5, 10, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT5C', 'A2-11', 3, 6, 11, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT5C', 'A2-14', 3, 7, 14, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT5C', 'A2-15', 3, 8, 15, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT5C', 'A2-18', 3, 9, 18, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT5C', 'A2-19', 3, 10, 19, ' ',1);

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('65', 'A2-01', 'SMT5C', 'A2-02', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('65', 'A2-05', 'SMT5C', 'A2-06', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('65', 'A2-09', 'SMT5C', 'A2-10', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('65', 'A2-13', 'SMT5C', 'A2-14', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('65', 'A2-17', 'SMT5C', 'A2-18', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMT5C', 'A2-03', '65', 'A2-04', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMT5C', 'A2-07', '65', 'A2-08', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMT5C', 'A2-11', '65', 'A2-12', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMT5C', 'A2-15', '65', 'A2-16', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMT5C', 'A2-19', '65', 'A2-20', ' ');


--SMT6C (6F產線)
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT6C', 'A3-02', 3, 1, 2, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT6C', 'A3-03', 3, 2, 3, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT6C', 'A3-06', 3, 3, 6, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT6C', 'A3-07', 3, 4, 7, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT6C', 'A3-10', 3, 5, 10, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT6C', 'A3-11', 3, 6, 11, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT6C', 'A3-14', 3, 7, 14, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT6C', 'A3-15', 3, 8, 15, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT6C', 'A3-18', 3, 9, 18, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMT6C', 'A3-19', 3, 10, 19, ' ',1);

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('66', 'A3-01', 'SMT6C', 'A3-02', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('66', 'A3-05', 'SMT6C', 'A3-06', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('66', 'A3-09', 'SMT6C', 'A3-10', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('66', 'A3-13', 'SMT6C', 'A3-14', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('66', 'A3-17', 'SMT6C', 'A3-18', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMT6C', 'A3-03', '66', 'A3-04', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMT6C', 'A3-07', '66', 'A3-08', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMT6C', 'A3-11', '66', 'A3-12', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMT6C', 'A3-15', '66', 'A3-16', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMT6C', 'A3-19', '66', 'A3-20', ' ');


--SMTC (產線)
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMTC', 'S1-38', 3, 1, 38, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMTC', 'S1-39', 3, 2, 39, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMTC', 'S1-42', 3, 3, 42, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMTC', 'S1-43', 3, 4, 43, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMTC', 'S1-46', 3, 5, 46, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMTC', 'S1-47', 3, 6, 47, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMTC', 'S3-38', 3, 7, 38, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMTC', 'S3-39', 3, 8, 39, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMTC', 'S3-42', 3, 9, 42, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMTC', 'S3-43', 3, 10, 43, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMTC', 'S3-46', 3, 11, 46, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMTC', 'S3-47', 3, 12, 47, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMTC', 'S5-38', 3, 13, 38, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('SMTC', 'S5-39', 3, 14, 39, ' ',1);

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'S1-37', 'SMTC', 'S1-38', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'S1-41', 'SMTC', 'S1-42', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'S1-45', 'SMTC', 'S1-46', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'S3-37', 'SMTC', 'S3-38', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'S3-41', 'SMTC', 'S3-42', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'S3-45', 'SMTC', 'S3-46', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'S5-37', 'SMTC', 'S5-38', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMTC', 'S1-39', '68', 'S1-40', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMTC', 'S1-43', '68', 'S1-44', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMTC', 'S1-47', '68', 'S1-48', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMTC', 'S3-39', '68', 'S3-40', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMTC', 'S3-43', '68', 'S3-44', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMTC', 'S3-47', '68', 'S3-48', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('SMTC', 'S5-39', '68', 'S5-40', ' ');


--線邊倉
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Line', 'A4-02', 3, 1, 2, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Line', 'A4-03', 3, 2, 3, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Line', 'A4-06', 3, 3, 6, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Line', 'A4-07', 3, 4, 7, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Line', 'A4-10', 3, 5, 10, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Line', 'A4-11', 3, 6, 11, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Line', 'A4-14', 3, 7, 14, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Line', 'A4-15', 3, 8, 15, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Line', 'A4-18', 3, 9, 18, ' ',1);
insert into PortDef (DeviceID, HostPortID, PortType, PortTypeIndex, PLCPortID, TrnDT, Direction) values('Line', 'A4-19', 3, 10, 19, ' ',1);

insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'A4-01', 'Line', 'A4-02', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'A4-05', 'Line', 'A4-06', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'A4-09', 'Line', 'A4-10', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'A4-13', 'Line', 'A4-14', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('68', 'A4-17', 'Line', 'A4-18', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Line', 'A4-03', '68', 'A4-04', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Line', 'A4-07', '68', 'A4-08', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Line', 'A4-11', '68', 'A4-12', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Line', 'A4-15', '68', 'A4-16', ' ');
insert INTO Routdef (DeviceID, HostPortID, NextDeviceID, NextHostPortID, TrnDT) VALUES('Line', 'A4-19', '68', 'A4-20', ' ');

