-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 03 Kwi 2023, 11:30
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
  `idArmor` int(11) NOT NULL,
  `nameArmor` text NOT NULL,
  `protectionArmor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `armor`
--

INSERT INTO `armor` (`idArmor`, `nameArmor`, `protectionArmor`) VALUES
(1, 'testPancerz', 5);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `charactercharacteristics`
--

CREATE TABLE `charactercharacteristics` (
  `idCharacteristics` int(11) NOT NULL,
  `weaponSkill` int(11) NOT NULL COMMENT 'walka wręcz',
  `ballisticSkill` int(11) NOT NULL COMMENT 'umiejętności strzeleckie',
  `strength` int(11) NOT NULL COMMENT 'krzepa',
  `toughness` int(11) NOT NULL COMMENT 'odporność',
  `agility` int(11) NOT NULL COMMENT 'zręczność',
  `intelligence` int(11) NOT NULL COMMENT 'inteligencja',
  `willPower` int(11) NOT NULL COMMENT 'siła woli',
  `fellowship` int(11) NOT NULL COMMENT 'ogłada',
  `attacks` int(11) NOT NULL COMMENT 'ataki',
  `wounds` int(11) NOT NULL COMMENT 'żywotność',
  `strengthBonus` int(11) NOT NULL COMMENT 'siła',
  `toughnessBonus` int(11) NOT NULL COMMENT 'wytrzymałość',
  `movement` int(11) NOT NULL COMMENT 'szybkość',
  `magic` int(11) NOT NULL COMMENT 'magia',
  `insanityPoints` int(11) NOT NULL COMMENT 'punkty opanowania',
  `fatePoints` int(11) NOT NULL COMMENT 'punkty przeznaczenia'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `charactercharacteristics`
--

INSERT INTO `charactercharacteristics` (`idCharacteristics`, `weaponSkill`, `ballisticSkill`, `strength`, `toughness`, `agility`, `intelligence`, `willPower`, `fellowship`, `attacks`, `wounds`, `strengthBonus`, `toughnessBonus`, `movement`, `magic`, `insanityPoints`, `fatePoints`) VALUES
(1, 40, 40, 40, 40, 30, 15, 10, 10, 3, 3, 3, 3, 3, 5, 3, 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `characterinfo`
--

CREATE TABLE `characterinfo` (
  `idCharakter` int(11) NOT NULL,
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

INSERT INTO `characterinfo` (`idCharakter`, `name`, `race`, `currentProfession`, `previousProfession`, `age`, `gender`) VALUES
(1, 'testTest', 'testRasa', 'testProfecja', 'testByłaProfesja', 404, 'testGender');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `equipment`
--

CREATE TABLE `equipment` (
  `idEquipment` int(11) NOT NULL,
  `nameEquipment` text CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci NOT NULL,
  `contentsEquipment` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `equipment`
--

INSERT INTO `equipment` (`idEquipment`, `nameEquipment`, `contentsEquipment`) VALUES
(1, 'testItem', 'loremIpsum');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `relationarmor`
--

CREATE TABLE `relationarmor` (
  `idRelationArmor` int(11) NOT NULL,
  `idCharacter` int(11) NOT NULL,
  `idArmor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `relationarmor`
--

INSERT INTO `relationarmor` (`idRelationArmor`, `idCharacter`, `idArmor`) VALUES
(1, 1, 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `relationcharecter`
--

CREATE TABLE `relationcharecter` (
  `id` int(11) NOT NULL,
  `idCharacter` int(11) NOT NULL,
  `idCharacteristics` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `relationcharecter`
--

INSERT INTO `relationcharecter` (`id`, `idCharacter`, `idCharacteristics`) VALUES
(1, 1, 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `relationtalents`
--

CREATE TABLE `relationtalents` (
  `idRelationTalent` int(11) NOT NULL,
  `idCharacter` int(11) NOT NULL,
  `idTalent` int(11) NOT NULL,
  `bonus+10` text DEFAULT NULL,
  `bonus+20` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `relationtalents`
--

INSERT INTO `relationtalents` (`idRelationTalent`, `idCharacter`, `idTalent`, `bonus+10`, `bonus+20`) VALUES
(1, 1, 1, 'tak', '');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `relationweapon`
--

CREATE TABLE `relationweapon` (
  `idRelationWeapon` int(11) NOT NULL,
  `idCharacter` int(11) NOT NULL,
  `idWeapon` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `relationweapon`
--

INSERT INTO `relationweapon` (`idRelationWeapon`, `idCharacter`, `idWeapon`) VALUES
(1, 1, 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `talents`
--

CREATE TABLE `talents` (
  `idTalent` int(11) NOT NULL,
  `nameTalent` text NOT NULL,
  `contentsTalent` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `talents`
--

INSERT INTO `talents` (`idTalent`, `nameTalent`, `contentsTalent`) VALUES
(1, 'testTalent', 'blablabla');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `weapon`
--

CREATE TABLE `weapon` (
  `idWeapon` int(11) NOT NULL,
  `nameWeapon` text NOT NULL,
  `damageWeapon` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `weapon`
--

INSERT INTO `weapon` (`idWeapon`, `nameWeapon`, `damageWeapon`) VALUES
(1, 'testMiecz', 3);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `armor`
--
ALTER TABLE `armor`
  ADD PRIMARY KEY (`idArmor`);

--
-- Indeksy dla tabeli `charactercharacteristics`
--
ALTER TABLE `charactercharacteristics`
  ADD PRIMARY KEY (`idCharacteristics`);

--
-- Indeksy dla tabeli `characterinfo`
--
ALTER TABLE `characterinfo`
  ADD PRIMARY KEY (`idCharakter`);

--
-- Indeksy dla tabeli `equipment`
--
ALTER TABLE `equipment`
  ADD PRIMARY KEY (`idEquipment`);

--
-- Indeksy dla tabeli `relationarmor`
--
ALTER TABLE `relationarmor`
  ADD PRIMARY KEY (`idRelationArmor`);

--
-- Indeksy dla tabeli `relationcharecter`
--
ALTER TABLE `relationcharecter`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `relationtalents`
--
ALTER TABLE `relationtalents`
  ADD PRIMARY KEY (`idRelationTalent`);

--
-- Indeksy dla tabeli `relationweapon`
--
ALTER TABLE `relationweapon`
  ADD PRIMARY KEY (`idRelationWeapon`);

--
-- Indeksy dla tabeli `talents`
--
ALTER TABLE `talents`
  ADD PRIMARY KEY (`idTalent`);

--
-- Indeksy dla tabeli `weapon`
--
ALTER TABLE `weapon`
  ADD PRIMARY KEY (`idWeapon`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `armor`
--
ALTER TABLE `armor`
  MODIFY `idArmor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `charactercharacteristics`
--
ALTER TABLE `charactercharacteristics`
  MODIFY `idCharacteristics` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `characterinfo`
--
ALTER TABLE `characterinfo`
  MODIFY `idCharakter` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `equipment`
--
ALTER TABLE `equipment`
  MODIFY `idEquipment` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `relationarmor`
--
ALTER TABLE `relationarmor`
  MODIFY `idRelationArmor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `relationcharecter`
--
ALTER TABLE `relationcharecter`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `relationtalents`
--
ALTER TABLE `relationtalents`
  MODIFY `idRelationTalent` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT dla tabeli `relationweapon`
--
ALTER TABLE `relationweapon`
  MODIFY `idRelationWeapon` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `talents`
--
ALTER TABLE `talents`
  MODIFY `idTalent` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `weapon`
--
ALTER TABLE `weapon`
  MODIFY `idWeapon` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
