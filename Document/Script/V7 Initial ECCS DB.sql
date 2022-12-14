Drop Table CtrlHS;
CREATE TABLE CtrlHS(EquNo VARCHAR(2) NOT NULL,HS VARCHAR(1) NOT NULL,TrnDT VARCHAR(20) DEFAULT ' ',PRIMARY KEY(EquNo));
Drop Table EquPlcData;
CREATE TABLE EquPlcData(EquNo VARCHAR(2) NOT NULL,SerialNo VARCHAR(5) NOT NULL, EquType VARCHAR(1) DEFAULT '1',EquPlcData VARCHAR(8000) DEFAULT ' ',TrnDT VARCHAR(20) DEFAULT ' ',PRIMARY KEY(EquNo, SerialNo));
Drop Table EquCmd;
CREATE TABLE EquCmd(
CmdSno VARCHAR(5) NOT NULL,
EquNo VARCHAR(2) NOT NULL,
CmdMode VARCHAR(2) NOT NULL,
CmdSts VARCHAR(2) NOT NULL, 
Source VARCHAR(7) NOT NULL DEFAULT ' ', 
Destination VARCHAR(7) NOT NULL DEFAULT ' ',
LocSize VARCHAR(3) NOT NULL DEFAULT '0',
Priority VARCHAR(2) NOT NULL DEFAULT '5',
RCVDT VARCHAR(20) NOT NULL DEFAULT ' ',
ACTDT VARCHAR(20) NOT NULL DEFAULT ' ',
CSTPresenceDT VARCHAR(20) NOT NULL DEFAULT ' ',
ENDDT VARCHAR(20) NOT NULL DEFAULT ' ',
CompleteCode VARCHAR(5) NOT NULL DEFAULT ' ',
CompleteIndex VARCHAR(5) NOT NULL DEFAULT ' ',
CarNo VARCHAR(2) NOT NULL DEFAULT '1',
ReNewFlag VARCHAR(1) NOT NULL DEFAULT 'N',
SpeedLevel VARCHAR(5) NOT NULL DEFAULT '3',
PRIMARY KEY(EquNo,CmdSno,CmdMode)
);

Drop Table EquCmdHis;
CREATE TABLE EquCmdHis(
HISDT VARCHAR(30) NOT NULL,
CmdSno VARCHAR(5) NOT NULL,
EquNo VARCHAR(2) NOT NULL,
CmdMode VARCHAR(2) NOT NULL,
CmdSts VARCHAR(2) NOT NULL,
Source VARCHAR(7) NOT NULL DEFAULT ' ',
Destination VARCHAR(7) NOT NULL DEFAULT ' ',
LocSize VARCHAR(3) NOT NULL DEFAULT '0', 
Priority VARCHAR(2) NOT NULL DEFAULT '5',
RCVDT VARCHAR(20) NOT NULL DEFAULT ' ',
ACTDT VARCHAR(20) NOT NULL DEFAULT ' ',
CSTPresenceDT VARCHAR(20) NOT NULL DEFAULT ' ',
ENDDT VARCHAR(20) NOT NULL DEFAULT ' ',
CompleteCode VARCHAR(5) NOT NULL DEFAULT ' ',
CompleteIndex VARCHAR(5) NOT NULL DEFAULT ' ',
CarNo VARCHAR(2) NOT NULL DEFAULT ' ',
ReNewFlag VARCHAR(1) NOT NULL DEFAULT 'N',
SpeedLevel VARCHAR(5) NOT NULL DEFAULT '0'
);

Drop Table EquCodeDef;
CREATE TABLE EquCodeDef(CodeType VARCHAR(25) NOT NULL,Code  VARCHAR(5) NOT NULL,Desc_TW  VARCHAR(250) DEFAULT ' ',Desc_EN  VARCHAR(250) DEFAULT ' ',PRIMARY KEY(CodeType,Code));
Drop Table EquStsLog;
CREATE TABLE EquStsLog( EquNo VARCHAR(2) NOT NULL,CarNo VARCHAR(2) DEFAULT '0' NOT NULL,StrDT VARCHAR(20) NOT NULL,EndDT VARCHAR(20) DEFAULT ' ',EquSts VARCHAR(1) NOT NULL,TotalSecs Int DEFAULT 0,PRIMARY KEY (EquNo,CarNo,StrDT,EquSts));
Drop Table EquModeLog;
CREATE TABLE EquModeLog(EquNo VARCHAR(2) NOT NULL,CarNo VARCHAR(2) DEFAULT '0' NOT NULL,StrDT VARCHAR(20) NOT NULL,EndDT VARCHAR(20) DEFAULT ' ',EquMode VARCHAR(1) NOT NULL,TotalSecs Int DEFAULT 0,PRIMARY KEY (EquNo,CarNo,StrDT,EquMode));

Drop Table AlarmDef;
CREATE TABLE AlarmDef(AlarmCode VARCHAR(10) NOT NULL,
AlarmLevel VARCHAR(1) DEFAULT ' ',
AlarmDesc VARCHAR(250) DEFAULT ' ',
AlarmDesc_EN VARCHAR(250) DEFAULT ' ',
PRIMARY KEY(AlarmCode));

Drop Table AlarmLog;
CREATE TABLE AlarmLog(EquNo VARCHAR(2) NOT NULL,
EquMode VARCHAR(1) NOT NULL Default '',
AlarmCode VARCHAR(10) NOT NULL,
AlarmSts VARCHAR(1) NOT NULL,
STRDT  VARCHAR(20) NOT NULL,
CLRDT  VARCHAR(20) DEFAULT ' ',
TOTALSECS INT DEFAULT 0,
PRIMARY KEY(EQUNO,ALARMCODE,STRDT));

Drop Table EquTrnLOG;
CREATE TABLE EquTrnLOG(TrnDT VARCHAR(30) NOT NULL,CmdSno VARCHAR(5) DEFAULT ' ' NOT NULL,EquNo VARCHAR(2) DEFAULT ' ' NOT NULL,CmdMode VARCHAR(2) DEFAULT ' ' NOT NULL,CmdSts VARCHAR(1) DEFAULT ' ',Source VARCHAR(7) DEFAULT ' ',Destination VARCHAR(7) DEFAULT ' ',LocSize VARCHAR(3) DEFAULT ' ',CompleteCode VARCHAR(5) DEFAULT ' ',CompleteIndex VARCHAR(5) DEFAULT ' ',CarNo VARCHAR(2) DEFAULT ' ',TrnUserID VARCHAR(20) NOT NULL,TrnDesc VARCHAR(200) DEFAULT ' ',SpeedLevel VARCHAR(5) DEFAULT '0',PRIMARY KEY(TrnDT,CmdSno,EquNo,CmdMode));
Drop Table EquCmdDetailLog;
CREATE TABLE EquCmdDetailLog(LogDT VARCHAR(30) NOT NULL,CmdSno VARCHAR(5) NOT NULL,EquNo VARCHAR(2) NOT NULL,CmdMode VARCHAR(2) NOT NULL,FBank VARCHAR(2) DEFAULT ' ',FBayLevel VARCHAR(5) DEFAULT ' ',TBank VARCHAR(2) DEFAULT ' ',TBayLevel VARCHAR(5) DEFAULT ' ', TransferInfo VARCHAR(4) DEFAULT ' ',WriteBuffer VARCHAR(35) DEFAULT ' ',WritePLC VARCHAR(20) DEFAULT ' ',StartAction VARCHAR(20) DEFAULT ' ',Cycle1 VARCHAR(20) DEFAULT ' ',Fork1 VARCHAR(20) DEFAULT ' ',LoadPresence_On VARCHAR(20) DEFAULT ' ',CSTPresence_On VARCHAR(20) DEFAULT ' ',Cycle2 VARCHAR(20) DEFAULT ' ',Fork2 VARCHAR(20) DEFAULT ' ',LoadPresence_Off VARCHAR(20) DEFAULT ' ',CSTPresence_Off VARCHAR(20) DEFAULT ' ',CmdFinish VARCHAR(20) DEFAULT ' ',CompleteCode VARCHAR(2) DEFAULT ' ',PLCTimerCount VARCHAR(5) DEFAULT ' ',Notes  VARCHAR(100) DEFAULT ' ',SpeedLevel VARCHAR(5) DEFAULT '0',PRIMARY KEY (LogDT,CmdSno,CmdMode,EquNo));
Drop Table EquMplcCmdHis;
CREATE TABLE EquMplcCmdHis(EquNo VARCHAR(2) NOT NULL,D0 VARCHAR(5) NOT NULL,D1 VARCHAR(5) NOT NULL,D2 VARCHAR(5) DEFAULT ' ',D3 VARCHAR(5) DEFAULT ' ',D4 VARCHAR(5) DEFAULT ' ',D5 VARCHAR(5) DEFAULT ' ',D6 VARCHAR(5) DEFAULT ' ',D7 VARCHAR(5) DEFAULT ' ',D8 VARCHAR(5) DEFAULT ' ',D9 VARCHAR(5) DEFAULT ' ',D10 VARCHAR(5) DEFAULT ' ',D11 VARCHAR(5) DEFAULT ' ',D12 VARCHAR(5) DEFAULT ' ',D13 VARCHAR(5) DEFAULT ' ',D14 VARCHAR(5) NOT NULL,LogDT VARCHAR(30) DEFAULT ' ' NOT NULL,PRIMARY KEY (LogDT,EquNo,D0,D1,D14));

Drop Table CV_PlcData;
Create Table CV_PlcData (
CV_No	Varchar (2)	Not Null		,
CV_Type	Varchar (1)	Not Null                ,
PlcData	Varchar (5000)		   Default ' '  ,
TrnDT	Varchar (20)		   Default ' '  ,
Primary Key ( CV_No,CV_Type ) ) ;

Delete From EquCodeDef;
insert into EquCodeDef(codetype,code,desc_tw)values('EquSts','A','動作中');
insert into EquCodeDef(codetype,code,desc_tw)values('EquSts','E','異常中');
insert into EquCodeDef(codetype,code,desc_tw)values('EquSts','W','待機中');
insert into EquCodeDef(codetype,code,desc_tw)values('EquSts','I','檢查命令中');
insert into EquCodeDef(codetype,code,desc_tw)values('EquSts','X','未連線');
insert into EquCodeDef(codetype,code,desc_tw)values('EquSts','N','電腦離線');
insert into EquCodeDef(codetype,code,desc_tw)values('EquMode','I','地上盤維護模式');
insert into EquCodeDef(codetype,code,desc_tw)values('EquMode','M','車上盤維護模式');
insert into EquCodeDef(codetype,code,desc_tw)values('EquMode','R','地上盤模式');
insert into EquCodeDef(codetype,code,desc_tw)values('EquMode','C','電腦連線模式');
insert into EquCodeDef(codetype,code,desc_tw)values('EquMode','X','未連線');
insert into EquCodeDef(codetype,code,desc_tw)values('EquMode','N','電腦離線');
insert into EquCodeDef(codetype,code,desc_tw)values('CmdMode','1','StoreIn 入庫');
insert into EquCodeDef(codetype,code,desc_tw)values('CmdMode','2','StoreOut 出庫');
insert into EquCodeDef(codetype,code,desc_tw)values('CmdMode','4','S2S 站對站');
insert into EquCodeDef(codetype,code,desc_tw)values('CmdMode','5','L2L 庫對庫');
insert into EquCodeDef(codetype,code,desc_tw)values('CmdMode','6','Move 移動');
insert into EquCodeDef(codetype,code,desc_tw)values('CmdMode','7','Scan 掃描');
insert into EquCodeDef(codetype,code,desc_tw)values('CmdMode','8','PickUp 取物');
insert into EquCodeDef(codetype,code,desc_tw)values('CmdMode','9','Deposit 置物');
insert into EquCodeDef(codetype,code,desc_tw)values('CmdSts','0','初始階段');
insert into EquCodeDef(codetype,code,desc_tw)values('CmdSts','1','寫入PLC');
insert into EquCodeDef(codetype,code,desc_tw)values('CmdSts','6','使用者強制取消命令');
insert into EquCodeDef(codetype,code,desc_tw)values('CmdSts','7','使用者強制完成命令');
insert into EquCodeDef(codetype,code,desc_tw)values('CmdSts','8','系統自動取消命令');
insert into EquCodeDef(codetype,code,desc_tw)values('CmdSts','9','系統自動完成命令');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','C0','取物 T2 time out');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','C1','取物檢測到EQ L-REQ訊號ON');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','C2','取物檢測到EQ U-REQ訊號OFF');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','C3','取物檢測到EQ Ready訊號ON');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','C4','RM取物前行程EQ Online信號中斷');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','C5','RM取物Tr-on檢測到EQ RY信號中斷');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','C6','EQ Port站口無物');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','C7','EQ Port不允許Fork存取');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','C8','取物 T5 time out');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','C9','RM取物完檢測到EQ U-REQ訊號ON');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','CA','RM取物完檢測到EQ Online OFF');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','D0','置物 T2 time out');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','D1','置物檢測到EQ L-REQ訊號OFF');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','D2','置物檢測到EQ U-REQ訊號ON');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','D3','置物檢測到EQ Ready訊號ON');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','D4','RM置物前行程EQ Online信號中斷');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','D5','RM置物Tr-on檢測到EQ RY信號中斷');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','D6','EQ Port站口有物');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','D7','EQ Port不允許Fork存置');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','D8','置物 T5 time out');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','D9','RM置物完檢測到EQ L-REQ訊號ON');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','DA','RM置物完檢測到EQ Online OFF');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','E0','Inline Interlock Error(On-Line)');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','E1','Transfer Request Wrong.');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','E2','儲位空出庫');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','E3','Scan ID Read Error');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','E4','ID Mismatch');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','E5','Scan No Response');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','E6','檢知無CST');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','E7','ID Read Error');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','E8','No Response');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','E9','From Command about');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','EA','Move/Scan command about');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','EB','Cassette Type MissMach');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','EC','Double storage');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','ED','Inline Interlock Error(LD)');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','EE','Inline Interlock Error(ULD)');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','EF','To Command about');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','91','From Return code Ack');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','92','To Return code');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','94','Crane is running retry moving');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','97','Scan complete');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','W1','車上盤狀態未Ready');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','W2','命令模式錯誤');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','W3','來源站無存取車取物訊號');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','W4','目的站無存取車置物訊號');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','W5','超出範圍');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','W6','異動儲位不存在');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','WA','WA');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','P1','站 超過最大範圍');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','P2','車上盤無物 不接收命令');
Insert into EquCodeDef(codetype,code,desc_tw)values('CompleteCode','P3','車上盤有物 不接收命令');

Delete From AlarmDef;
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0100','A','命令資料出現錯誤','Shelf data error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0101','A','命令資料錯誤','Shelf data error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0102','A','叉臂不在中央','Shelf data error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0103','A','有貨物在叉臂上，堆垛機卻接收取物命令','Shelf data error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0104','A','沒有貨物在叉臂上，堆垛機卻接收置物命令','Shelf data error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0105','A','BCR讀取請求錯誤','Shelf data error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0108','A','Reserved','Shelf data error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0200','A','儲位空出庫','Empty retrieval at a shelf');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0300','A','檢測到儲位二重格','Double storage error at a left bank shelf');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0303','A','列一儲位二重格','Double storage error at a left bank shelf');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0304','A','列二儲位二重格','Double storage error at a right bank shelf');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0305','A','列三儲位二重格','Double storage error at a left bank shelf');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0306','A','列四儲位二重格','Double storage error at a right bank shelf');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0307','A','列三取物時，檢測到前庫位有物','Double storage error at a right bank shelf');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0308','A','列四取物時，檢測到前庫位有物','Double storage error at a right bank shelf');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0309','A','列三置物時，檢測到前庫位有物','Double storage error at a right bank shelf');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0310','A','列四置物時，檢測到前庫位有物','Double storage error at a right bank shelf');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0311','A','叉臂左伸動線未淨空','Double storage error at a right bank shelf');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0312','A','叉臂右伸動線未淨空','Double storage error at a right bank shelf');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0313','A','叉臂左伸編碼值超出誤差值','Double storage error at a right bank shelf');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0314','A','叉臂右伸編碼值超出誤差值','Double storage error at a right bank shelf');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0400','A','周邊站口空取出','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4000','A','回轉HP Sensor檢測異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4401','A','回轉超時-定位','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4402','A','回轉超時-回HOME','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4501','A','回轉動作中異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4502','A','回轉動作中異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4E01','A','回轉編碼器異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4E02','A','回轉編碼器異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4700','A','回轉驅動器異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4701','A','回轉伺服異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4800','A','回轉HP Sensor 感測異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4801','A','回轉HP Sensor異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4900','A','回轉OP Sensor 感測異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4901','A','回轉OP Sensor異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4A00','A','回轉HP極限 Sensor異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('4B00','A','回轉OP極限 Sensor異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('7101','A','走行 BCR No response','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('7102','A','走行 BCR Reads  Error','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('7103','A','走行 BCR Reads  ID  Error','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('7104','A','Reserved','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('7105','A','列1 BCR 異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('7401','A','HP 障礙物檢測','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('7402','A','OP 障礙物檢測','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('7403','A','車上盤電控箱開門檢知','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('7404','A','OP SVO 電控箱開門檢知','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('7405','A','HP SVO 電控箱開門檢知','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('7205','A','列2 BCR 異常','Empty retrival at a port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0500','A','周邊站口二重格','Double storage at a PORT');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0601','A','貨物後超寬異常','Load sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0602','A','貨物前超寬異常','Load sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0603','A','貨物左超長異常','Load sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0604','A','貨物右超長異常','Load sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0605','A','貨物超高異常','Load sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0606','A','堆垛異常','Load sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0700','A','置物之後檢測到叉臂有物','Presense on fork after depositing');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0800','A','左側儲位(Shelf)二重格SEN異常','Presense on fork after depositing');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0900','A','右側儲位(Shelf)二重格SEN異常','Presense on fork after depositing');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0A00','A','左側站口(Port)二重格SEN異常','Presense on fork after depositing');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0B00','A','右側站口(Port)二重格SEN異常','Presense on fork after depositing');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A205','A','目的周邊站不允許此貨物','CST type detected by Crane is different from destination');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('0F00','A','貨物超出第二選配寬度異常','High-low reflection sheet error at shelf or port');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1000','A','走行原點sensor檢測異常','Travel HP sensor error detection');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1401','A','走行自動運轉定位超時','Travel cycle timer timed out');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1402','A','走行原點複歸超時','Travel HP return timer timed out');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1500','A','走行動作中異常','Travel HP return timer timed out');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1701','A','走行驅動器異常','Travel driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1702','A','走行驅動器異常','Travel driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1703','A','走行驅動器異常','Travel driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1704','A','走行驅動器異常','Travel driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1800','A','走行HP側儲位(Shelf)走行定位板檢測異常','Travel driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1801','A','走行OP側儲位(Shelf)走行定位板檢測異常','Travel driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1900','A','走行HP側PORT走行定位板檢測異常','Travel driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1901','A','走行OP側PORT走行定位板檢測異常','Travel driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1A00','A','走行後極限Sensor異常','Travel HP-ES sensor error detection');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1B00','A','走行前極限Sensor異常','Travel OP-ES sensor error detection');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1D01','A','走行滑差','Travel distance exceeded');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1D02','A','走行滑差','Travel distance exceeded');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1D03','A','走行 EN 與 LASER 差異','Travel distance exceeded');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1D04','A','雷射後極限異常','Travel distance exceeded');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1D05','A','雷射前極限異常','Travel distance exceeded');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1400','A','走行超時-定位','Travel distance exceeded');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1E01','A','走行編碼器異常','Travel encoder error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1E02','A','走行編碼器異常','Travel encoder error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1E03','A','走行編碼器異常','Travel encoder error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1E04','A','走行編碼器異常','Travel encoder error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1E05','A','目的位置超出所設定最大雷射值','Travel encoder error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1E06','A','目的位置小於所設定最小雷射值','Travel encoder error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1E07','A','走行後減速板位置檢知異常','Travel encoder error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('1E08','A','走行前減速板位置檢知異常','Travel encoder error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2000','A','升降原點SENSOR檢測異常','Lift HP side home position sensor error detection');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2100','A','升降OP側原點Sensor檢測異常','Lift HP side home position sensor error detection');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2101','A','叉臂縮回時,平臺荷有檢知ON','Lift cycle timer timed out-position');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2102','A','升降防頃 sensor 異常','Lift cycle timer timed out-position');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2401','A','升降自動運轉定位超時','Lift cycle timer timed out-position');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2402','A','升降原點複歸超時','Lift HP return timer timed out-return home');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2403','A','升降高低位移動運轉超時','Lift zone displacement timer timed out');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2500','A','升降動作中異常','Lift activation condition error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2504','A','升降動作中異常','Lift activation condition error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2701','A','升降驅動器異常','Lift driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2702','A','升降驅動器異常','Lift driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2703','A','升降驅動器異常','Lift driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2704','A','升降驅動器異常','Lift driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2800','A','升降HP側儲位(Shelf)升降定位板檢測異常','Lift driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2801','A','升降OP側儲位(Shelf)升降定位板檢測異常','Lift driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2900','A','升降HP側PORT走行定位板檢測異常','Lift driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2901','A','升降OP側PORT走行定位板檢測異常','Lift driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2A00','A','升降上極限Sensor異常','Lift HP side upper limit sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2A01','A','升降雷射超過最大設定值異常','Lift OP side upper limit sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2B00','A','升降下極限Sensor異常','Lift HP side lower limit sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2B01','A','升降雷射超過最小設定值異常','Lift OP side lower limit sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2D01','A','升降上減速板位置檢知異常','Lift displacement exceed the zone limit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2D02','A','升降下減速板位置檢知異常','Lift displacement exceed the zone limit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2D03','A','升降位移超過區域','Lift displacement exceed the zone limit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2D04','A','升降位移超過區域','Lift displacement exceed the zone limit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2E01','A','升降編碼器異常','Lift displacement exceed the zone limit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2E02','A','升降編碼器異常','Lift displacement exceed the zone limit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2E03','A','升降編碼器異常','Lift displacement exceed the zone limit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('2E04','A','升降編碼器異常','Lift displacement exceed the zone limit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3000','A','叉臂HP Sensor 檢測異常','Fork slipped out of fork HP during movement');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3100','A','叉臂滑動異常','Fork slipped out of fork HP during movement');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3401','A','叉臂運轉超時','Fork cycle timer timed out');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3402','A','叉臂超時-回HOME','Fork cycle timer timed out');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3501','A','叉臂動作中異常','Fork cycle timer timed out');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3701','A','叉臂驅動器異常','Fork driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3702','A','叉臂伺服異常','Fork driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3800','A','叉臂HP Sensor檢測異常','Fork driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3801','A','叉臂HP Sensor異常','Fork driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3900','A','叉臂OP Sensor檢測異常','Fork driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3901','A','叉臂OP Sensor異常','Fork driver error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3A00','A','叉臂左伸極限異常','Fork HP-ES sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3A01','A','叉臂右伸極限異常','Fork OP-ES sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('7601','A','雷射異常','X-Ray irradiation error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3E01','A','叉臂編碼器異常','Fork OP-ES sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3E02','A','叉臂編碼器異常','Fork OP-ES sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3E03','A','叉臂編碼器異常','Fork OP-ES sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('3E04','A','叉臂編碼器異常','Fork OP-ES sensor error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('7602','A','雷射異常(升降)','X-Ray irradiation error(RM travel HP return)');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9000','A','光通訊異常','HP optical transmission advice communication error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9200','A','維護進入','Maintenance access open');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9B01','A','取物邏輯異常','HP-H belt disconnection when going up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9B02','A','取物邏輯異常','HP-H belt disconnection when going down');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9601','A','鋼索斷裂檢知','HP-H belt disconnection when going up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9602','A','鋼索過長檢知','HP-H belt disconnection when going down');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9603','A','捲揚機過行程檢知','HP-O belt disconnection when going up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9604','A','HP-O下降皮帶斷裂','HP-O belt disconnection when going up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9E00','A','原點迷失','HP-H belt disconnection when going down');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9E01','A','走行原點迷失','HP-H belt disconnection when going up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9E02','A','升降原點迷失','HP-H belt disconnection when going down');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9E03','A','回轉原點迷失','HP-O belt disconnection when going up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9E04','A','叉臂原點迷失','HP-O belt disconnection when going up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9605','A','OP-H上升降皮帶斷裂','HP-O belt disconnection when going up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9606','A','OP-H下降皮帶斷裂','HP-O belt disconnection when going up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9607','A','OP-O上升降皮帶斷裂','HP-O belt disconnection when going up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9608','A','OP-O下降皮帶斷裂','HP-O belt disconnection when going up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9F01','A','車上盤緊急停止','Emergency stop');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9F02','A','警急停止','Emergency stop');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9F03','A','警急停止','Emergency stop');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9F04','A','警急停止','Emergency stop');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9A00','A','置物後發生貨物異常','Emergency stop');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9F05','A','地上盤緊急停止','Emergency stop');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9F06','A','警急停止','Emergency stop');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9F07','A','HP側安全門感測器動作','Emergency stop');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9F08','A','OP側安全門感測器動作','Emergency stop');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9F09','A','HP BUMP感測器動作','Emergency stop');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9F0A','A','OP BUMP感測器動作','Emergency stop');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A001','A','RM運轉前檢測到命令異常','Fork not on HP(Initial position)');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A002','A','叉臂不在中央','Fork not on HP(Initial position)');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A201','A','有貨物在叉臂上 堆垛機收到取物命令','Crane detects command error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A202','A','沒有貨物在叉臂上 堆垛機收到置物命令','Crane detects command error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A203','A','BCR讀取請求錯誤','Crane detects command error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A204','A','CST TYPE Mismatch','Crane detects command error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A206','A','CST ID Mismatch','Crane detects command error');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A300','A','取物  T2 time out','Detect EQ L-REQ ON error when RM pick up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A301','A','取物  T4 time out','Detect EQ L-REQ ON error when RM pick up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A302','A','取物  T5 time out','Detect EQ L-REQ ON error when RM pick up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A303','A','對站口取物時，檢測到站訊號異常','Detect EQ L-REQ ON error when RM pick up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A304','A','取物檢測到 EQ U-REQ 訊號 OFF','Detect EQ L-REQ ON error when RM pick up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A305','A','取物檢測到 EQ -READY 訊號 ON','Detect EQ L-REQ ON error when RM pick up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A306','A','RM取物前行程EQ On-line  or RDY信號中斷','Detect EQ L-REQ ON error when RM pick up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A307','A','RM取物 Tr-on檢測到EQ RY信號中斷','Detect EQ L-REQ ON error when RM pick up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A308','A','RM取物，檢測到 EQ On-L 訊號 OFF','Detect EQ L-REQ ON error when RM pick up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A309','A','堆垛機取物完 檢測到站口荷有訊號','Detect EQ U-REQ ON error after RM pick up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A30F','A','RM取物時，周邊站口緊急停止信號中斷','Detect EQ Online OFF error after RM pick up');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A30A','A','存取站口編號比對異常','Detect EQ L-REQ OFF error when Crane deposit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A330','A','置物  T2 time out','Detect EQ L-REQ OFF error when Crane deposit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A331','A','置物  T4 time out','Detect EQ L-REQ OFF error when Crane deposit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A332','A','置物  T5 time out','Detect EQ L-REQ OFF error when Crane deposit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A333','A','對站口置物，檢測到站訊號異常','Detect EQ L-REQ OFF error when Crane deposit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A334','A','置物檢測到 EQ U-REQ 訊號 ON','Detect EQ L-REQ OFF error when Crane deposit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A335','A','置物檢測到 EQ -READY 訊號 ON','Detect EQ L-REQ OFF error when Crane deposit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A336','A','RM置物前行程EQ On-line信號中斷','Detect EQ L-REQ OFF error when Crane deposit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A337','A','RM置物R-ON 檢測到EQ RY信號中斷','Detect EQ L-REQ OFF error when Crane deposit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A338','A','RM置物，檢測到 EQ On-L or RDY訊號 OFF','Detect EQ L-REQ OFF error when Crane deposit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A339','A','堆垛機置物完 未檢測到站口荷有訊號','Detect EQ L-REQ ON error after RM deposit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A33F','A','堆垛機對站口置物時 檢測到站口緊停','Detect EQ Online OFF error after RM deposit');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A500','A','HP地上盤EMO緊急停止','HP RCD EMO Emergency stop');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A501','A','OP地上盤EMS緊急停止','HP RCD EMO Emergency stop');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A502','A','HP側門鎖被開啟','Door is open at HP side');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A503','A','OP側門鎖被開啟','Door is open at HP side');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A506','A','左側安全拉繩緊急停止','Door is open at HP side');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A507','A','右側安全拉繩緊急停止','Door is open at HP side');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A509','A','周邊站口緊急停止','Door is open at HP side');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('A50A','A','與Crane通訊品質不良','Door is open at HP side');
Insert into AlarmDef(AlarmCode,AlarmLevel,AlarmDesc,AlarmDesc_EN) values ('9001','A','OP光通訊異常','Door is open at HP side');

