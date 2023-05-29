-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 29 Maj 2023, 09:25
-- Wersja serwera: 10.4.27-MariaDB
-- Wersja PHP: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `chg`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `armor`
--

CREATE TABLE `armor` (
  `armorID` int(11) NOT NULL,
  `armorName` text NOT NULL,
  `armorProtection` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `armor`
--

INSERT INTO `armor` (`armorID`, `armorName`, `armorProtection`) VALUES
(1, 'testPancerz', 5);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `charactercharacteristics`
--

CREATE TABLE `charactercharacteristics` (
  `characteristicsID` int(11) NOT NULL,
  `characteristicsName` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `charactercharacteristics`
--

INSERT INTO `charactercharacteristics` (`characteristicsID`, `characteristicsName`) VALUES
(1, 'weaponSkill'),
(2, 'ballisticSkill'),
(3, 'strength'),
(4, 'toughness'),
(5, 'agility'),
(6, 'intelligence'),
(7, 'willPower'),
(8, 'fellowship'),
(9, 'attacks'),
(10, 'wounds'),
(11, 'strengthBonus'),
(12, 'toughnessBonus'),
(13, 'movement'),
(14, 'magic'),
(15, 'insanityPoints'),
(16, 'fatePoints');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `characterinfo`
--

CREATE TABLE `characterinfo` (
  `characterID` int(11) NOT NULL,
  `name` text NOT NULL,
  `race` text NOT NULL,
  `currentProfession` text NOT NULL,
  `previousProfession` text NOT NULL,
  `age` int(11) NOT NULL,
  `gender` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `characterinfo`
--

INSERT INTO `characterinfo` (`characterID`, `name`, `race`, `currentProfession`, `previousProfession`, `age`, `gender`) VALUES
(1, 'testTest', 'testRasa', 'testProfecja', 'testByłaProfesja', 404, 'testGender'),
(2, 'none', 'noce', 'none', 'none', 1, 'none'),
(3, 'Tytus', 'Bomba', 'Kapitan', 'cieć', 107, 'M');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `equipment`
--

CREATE TABLE `equipment` (
  `equipmentID` int(11) NOT NULL,
  `equipmentName` text CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci NOT NULL,
  `equipmentContent` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `equipment`
--

INSERT INTO `equipment` (`equipmentID`, `equipmentName`, `equipmentContent`) VALUES
(1, 'testItem', 'loremIpsum');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `relationarmor`
--

CREATE TABLE `relationarmor` (
  `relationArmorID` int(11) NOT NULL,
  `characterID` int(11) NOT NULL,
  `armorID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `relationarmor`
--

INSERT INTO `relationarmor` (`relationArmorID`, `characterID`, `armorID`) VALUES
(1, 1, 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `relationcharecter`
--

CREATE TABLE `relationcharecter` (
  `ID` int(11) NOT NULL,
  `characterID` int(11) NOT NULL,
  `characteristicsID` int(11) NOT NULL,
  `characteristicsValue` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `relationcharecter`
--

INSERT INTO `relationcharecter` (`ID`, `characterID`, `characteristicsID`, `characteristicsValue`) VALUES
(1, 1, 2, 0),
(2, 2, 1, 0),
(3, 3, 3, 0),
(4, 1, 1, 14),
(6, 1, 3, 401),
(7, 1, 4, 14),
(8, 1, 5, 43),
(9, 1, 6, 24),
(10, 1, 7, 5),
(11, 1, 8, 2),
(12, 1, 9, 12),
(13, 3, 1, 404),
(14, 1, 13, 534),
(15, 1, 14, 74),
(16, 1, 15, 43),
(17, 1, 16, 32);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `relationequipment`
--

CREATE TABLE `relationequipment` (
  `relationEquipmentID` int(11) NOT NULL,
  `characterID` int(11) NOT NULL,
  `equipmentID` int(11) NOT NULL,
  `equipmentValue` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `relationtalents`
--

CREATE TABLE `relationtalents` (
  `relationTalentID` int(11) NOT NULL,
  `characterID` int(11) NOT NULL,
  `talentID` int(11) NOT NULL,
  `bonus+10` text DEFAULT NULL,
  `bonus+20` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `relationtalents`
--

INSERT INTO `relationtalents` (`relationTalentID`, `characterID`, `talentID`, `bonus+10`, `bonus+20`) VALUES
(1, 1, 1, 'tak', '');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `relationweapon`
--

CREATE TABLE `relationweapon` (
  `relationWeaponID` int(11) NOT NULL,
  `characterID` int(11) NOT NULL,
  `weaponID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `relationweapon`
--

INSERT INTO `relationweapon` (`relationWeaponID`, `characterID`, `weaponID`) VALUES
(1, 1, 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `talents`
--

CREATE TABLE `talents` (
  `talentID` int(11) NOT NULL,
  `talentName` text NOT NULL,
  `talentContent` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `talents`
--

INSERT INTO `talents` (`talentID`, `talentName`, `talentContent`) VALUES
(1, 'testTalent', 'blablabla'),
(2, 'test', 'lorem ipsum'),
(3, 'Pływanie', 'No nie zatoniesz'),
(4, 'Skakanie', 'Dalszy skok'),
(5, '34', '4');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `weapon`
--

CREATE TABLE `weapon` (
  `weaponID` int(11) NOT NULL,
  `weaponName` text NOT NULL,
  `weaponDamage` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `weapon`
--

INSERT INTO `weapon` (`weaponID`, `weaponName`, `weaponDamage`) VALUES
(1, 'testMiecz', 3);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `armor`
--
ALTER TABLE `armor`
  ADD PRIMARY KEY (`armorID`);

--
-- Indeksy dla tabeli `charactercharacteristics`
--
ALTER TABLE `charactercharacteristics`
  ADD PRIMARY KEY (`characteristicsID`);

--
-- Indeksy dla tabeli `characterinfo`
--
ALTER TABLE `characterinfo`
  ADD PRIMARY KEY (`characterID`);

--
-- Indeksy dla tabeli `equipment`
--
ALTER TABLE `equipment`
  ADD PRIMARY KEY (`equipmentID`);

--
-- Indeksy dla tabeli `relationarmor`
--
ALTER TABLE `relationarmor`
  ADD PRIMARY KEY (`relationArmorID`),
  ADD UNIQUE KEY `idCharacter` (`characterID`,`armorID`);

--
-- Indeksy dla tabeli `relationcharecter`
--
ALTER TABLE `relationcharecter`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `idCharacter` (`characterID`,`characteristicsID`),
  ADD UNIQUE KEY `characterID` (`characterID`,`characteristicsID`);

--
-- Indeksy dla tabeli `relationequipment`
--
ALTER TABLE `relationequipment`
  ADD PRIMARY KEY (`relationEquipmentID`);

--
-- Indeksy dla tabeli `relationtalents`
--
ALTER TABLE `relationtalents`
  ADD PRIMARY KEY (`relationTalentID`),
  ADD UNIQUE KEY `idCharacter` (`characterID`,`talentID`);

--
-- Indeksy dla tabeli `relationweapon`
--
ALTER TABLE `relationweapon`
  ADD PRIMARY KEY (`relationWeaponID`);

--
-- Indeksy dla tabeli `talents`
--
ALTER TABLE `talents`
  ADD PRIMARY KEY (`talentID`);

--
-- Indeksy dla tabeli `weapon`
--
ALTER TABLE `weapon`
  ADD PRIMARY KEY (`weaponID`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `armor`
--
ALTER TABLE `armor`
  MODIFY `armorID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `charactercharacteristics`
--
ALTER TABLE `charactercharacteristics`
  MODIFY `characteristicsID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT dla tabeli `characterinfo`
--
ALTER TABLE `characterinfo`
  MODIFY `characterID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `equipment`
--
ALTER TABLE `equipment`
  MODIFY `equipmentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `relationarmor`
--
ALTER TABLE `relationarmor`
  MODIFY `relationArmorID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `relationcharecter`
--
ALTER TABLE `relationcharecter`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT dla tabeli `relationequipment`
--
ALTER TABLE `relationequipment`
  MODIFY `relationEquipmentID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT dla tabeli `relationtalents`
--
ALTER TABLE `relationtalents`
  MODIFY `relationTalentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT dla tabeli `relationweapon`
--
ALTER TABLE `relationweapon`
  MODIFY `relationWeaponID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `talents`
--
ALTER TABLE `talents`
  MODIFY `talentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT dla tabeli `weapon`
--
ALTER TABLE `weapon`
  MODIFY `weaponID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
