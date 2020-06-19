-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- 主機： localhost:8787
-- 產生時間： 
-- 伺服器版本： 10.4.11-MariaDB
-- PHP 版本： 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 資料庫： `drinkShop`
--

-- --------------------------------------------------------

--
-- 資料表結構 `Ice`
--

CREATE TABLE `Ice` (
  `ID` int(11) NOT NULL,
  `Name` varchar(20) COLLATE utf8_unicode_520_ci NOT NULL,
  `Created` datetime DEFAULT NULL,
  `Modified` datetime DEFAULT NULL,
  `Remarks` varchar(50) COLLATE utf8_unicode_520_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_520_ci;

--
-- 傾印資料表的資料 `Ice`
--

INSERT INTO `Ice` (`ID`, `Name`, `Created`, `Modified`, `Remarks`) VALUES
(1, '全冰', NULL, NULL, NULL),
(2, '少冰', NULL, NULL, NULL),
(3, '微冰', NULL, NULL, NULL),
(4, '去冰', NULL, NULL, NULL),
(5, '溫', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `Items`
--

CREATE TABLE `Items` (
  `ID` int(11) NOT NULL,
  `Name` varchar(20) COLLATE utf8_unicode_520_ci NOT NULL,
  `CanIce` tinyint(1) NOT NULL,
  `CanSize` tinyint(1) NOT NULL,
  `CanSweetness` tinyint(1) NOT NULL,
  `BasePrice` int(11) NOT NULL,
  `AddPrice` int(11) NOT NULL,
  `Created` datetime DEFAULT NULL,
  `Modified` datetime DEFAULT NULL,
  `Remarks` varchar(50) COLLATE utf8_unicode_520_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_520_ci;

--
-- 傾印資料表的資料 `Items`
--

INSERT INTO `Items` (`ID`, `Name`, `CanIce`, `CanSize`, `CanSweetness`, `BasePrice`, `AddPrice`, `Created`, `Modified`, `Remarks`) VALUES
(1, '可樂', 0, 1, 0, 30, 5, NULL, NULL, NULL),
(2, '咖啡', 1, 1, 1, 60, 10, NULL, NULL, NULL),
(3, '奶茶', 1, 1, 1, 35, 5, NULL, NULL, NULL),
(4, '拿鐵', 1, 1, 1, 55, 10, NULL, NULL, NULL),
(5, '紅茶', 1, 1, 1, 25, 5, NULL, NULL, NULL),
(6, '綠茶', 1, 1, 1, 25, 5, NULL, NULL, NULL),
(7, '蜜茶', 1, 1, 1, 30, 5, NULL, NULL, NULL),
(8, '雪碧', 0, 1, 0, 30, 5, NULL, NULL, NULL),
(9, '青茶', 1, 1, 1, 25, 5, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `OrderItems`
--

CREATE TABLE `OrderItems` (
  `ID` bigint(20) NOT NULL,
  `ID_Order` int(11) NOT NULL,
  `ID_Item` int(11) NOT NULL,
  `Count` int(11) NOT NULL,
  `ID_Ice` int(11) NOT NULL,
  `ID_Size` int(11) NOT NULL,
  `ID_Sweetness` int(11) NOT NULL,
  `Price` int(11) NOT NULL,
  `Created` datetime DEFAULT NULL,
  `Modified` datetime DEFAULT NULL,
  `Remarks` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_520_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- 資料表結構 `Orders`
--

CREATE TABLE `Orders` (
  `ID` int(11) NOT NULL,
  `Phone` varchar(20) CHARACTER SET utf8 COLLATE utf8_unicode_520_ci NOT NULL,
  `ClientID` varchar(250) CHARACTER SET utf8 COLLATE utf8_unicode_520_ci NOT NULL,
  `Price` int(11) NOT NULL,
  `Payment` tinyint(1) NOT NULL,
  `Created` datetime DEFAULT NULL,
  `Modified` datetime DEFAULT NULL,
  `Remarks` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_520_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- 資料表結構 `Size`
--

CREATE TABLE `Size` (
  `ID` int(11) NOT NULL,
  `Name` varchar(20) COLLATE utf8_unicode_520_ci NOT NULL,
  `Created` datetime DEFAULT NULL,
  `Modified` datetime DEFAULT NULL,
  `Remarks` varchar(50) COLLATE utf8_unicode_520_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_520_ci;

--
-- 傾印資料表的資料 `Size`
--

INSERT INTO `Size` (`ID`, `Name`, `Created`, `Modified`, `Remarks`) VALUES
(1, 'Small', NULL, NULL, NULL),
(2, 'Medium', NULL, NULL, NULL),
(3, 'Large', NULL, NULL, NULL),
(4, 'Fat', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `Sweetness`
--

CREATE TABLE `Sweetness` (
  `ID` int(11) NOT NULL,
  `Name` varchar(20) COLLATE utf8_unicode_520_ci NOT NULL,
  `Created` datetime DEFAULT NULL,
  `Modified` datetime DEFAULT NULL,
  `Remarks` varchar(50) COLLATE utf8_unicode_520_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_520_ci;

--
-- 傾印資料表的資料 `Sweetness`
--

INSERT INTO `Sweetness` (`ID`, `Name`, `Created`, `Modified`, `Remarks`) VALUES
(1, '全糖', NULL, NULL, NULL),
(2, '少糖', NULL, NULL, NULL),
(3, '半糖', NULL, NULL, NULL),
(4, '微糖', NULL, NULL, NULL),
(5, '無糖', NULL, NULL, NULL);

--
-- 已傾印資料表的索引
--

--
-- 資料表索引 `Ice`
--
ALTER TABLE `Ice`
  ADD PRIMARY KEY (`ID`);

--
-- 資料表索引 `Items`
--
ALTER TABLE `Items`
  ADD PRIMARY KEY (`ID`);

--
-- 資料表索引 `OrderItems`
--
ALTER TABLE `OrderItems`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_Ice` (`ID_Ice`),
  ADD KEY `ID_Item` (`ID_Item`),
  ADD KEY `ID_Order` (`ID_Order`),
  ADD KEY `ID_Size` (`ID_Size`),
  ADD KEY `ID_Sweetness` (`ID_Sweetness`);

--
-- 資料表索引 `Orders`
--
ALTER TABLE `Orders`
  ADD PRIMARY KEY (`ID`);

--
-- 資料表索引 `Size`
--
ALTER TABLE `Size`
  ADD PRIMARY KEY (`ID`);

--
-- 資料表索引 `Sweetness`
--
ALTER TABLE `Sweetness`
  ADD PRIMARY KEY (`ID`);

--
-- 在傾印的資料表使用自動遞增(AUTO_INCREMENT)
--

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `Ice`
--
ALTER TABLE `Ice`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `Items`
--
ALTER TABLE `Items`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `OrderItems`
--
ALTER TABLE `OrderItems`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `Orders`
--
ALTER TABLE `Orders`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `Size`
--
ALTER TABLE `Size`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `Sweetness`
--
ALTER TABLE `Sweetness`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- 已傾印資料表的限制式
--

--
-- 資料表的限制式 `OrderItems`
--
ALTER TABLE `OrderItems`
  ADD CONSTRAINT `orderitems_ibfk_1` FOREIGN KEY (`ID_Ice`) REFERENCES `Ice` (`ID`),
  ADD CONSTRAINT `orderitems_ibfk_2` FOREIGN KEY (`ID_Item`) REFERENCES `Items` (`ID`),
  ADD CONSTRAINT `orderitems_ibfk_3` FOREIGN KEY (`ID_Order`) REFERENCES `Orders` (`ID`),
  ADD CONSTRAINT `orderitems_ibfk_4` FOREIGN KEY (`ID_Size`) REFERENCES `Size` (`ID`),
  ADD CONSTRAINT `orderitems_ibfk_5` FOREIGN KEY (`ID_Sweetness`) REFERENCES `Sweetness` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
