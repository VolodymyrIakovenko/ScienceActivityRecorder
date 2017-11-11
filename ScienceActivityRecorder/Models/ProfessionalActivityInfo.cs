﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScienceActivityRecorder.Models
{
    public class ProfessionalActivityInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime LastFillDate { get; set; }

        [Display(Name = "Наукове керівництво (консультування) здобувача, який одержав документ про присудження наукового ступеня")]
        public string Num4ScientificManagement { get; set; }

        [Display(Name = "Участь у міжнародному науковому проекті/залучення до міжнародної експертизи, наявність звання «суддя міжнародної категорії»")]
        public string Num5ParticipationInInternationalProjects { get; set; }

        [Display(Name = "Проведення навчальних занять іноземною мовою (крім мовних навчальних дисциплін) в обсязі не менше 50 аудиторних годин на навчальний рік")]
        public string Num6LecturesInForeignLanguage { get; set; }

        [Display(Name = "Робота у складі експертних рад з питань проведення експертизи дисертацій МОН або галузевих експертних рад Національного агентства із забезпечення якості вищої освіти, або Акредитаційної комісії, або їх експертних рад, або міжгалузевої експертної ради з вищої освіти Акредитаційної комісії, або трьох експертних комісій МОН/зазначеного Агентства, або Науково-методичної ради/науково-методичних комісій з вищої освіти МОН, або робочих груп з розроблення стандартів вищої освіти України")]
        public string Num7WorkInExpertBoard { get; set; }

        [Display(Name = "Виконання функцій наукового керівника або відповідального виконавця наукової теми (проекту), або головного редактора/члена редакційної колегії наукового видання, включеного до переліку наукових фахових видань України, або іноземного рецензованого наукового видання")]
        public string Num8ScientificGuidenceFunctions { get; set; }

        [Display(Name = "Керівництво студентом, який зайняв призове місце, або робота у складі організаційного комітету/журі/апеляційної комісії Міжнародної студентської олімпіади/II етапу Всеукраїнської студентської олімпіади (Всеукраїнського конкурсу студентських наукових робіт)/III—IV етапу Всеукраїнських учнівських олімпіад з базових навчальних предметів/II—III етапу Всеукраїнських конкурсів-захистів науково-дослідницьких робіт учнів — членів Малої академії наук; керівництво студентом, який став призером Олімпійських, Паралімпійських ігор, Всесвітньої та Всеукраїнської Універсіади, чемпіонату світу, Європи, Європейських ігор, етапів Кубку світу та Європи, чемпіонату України; виконання обов’язків головного секретаря, головного судді, судді міжнародних та всеукраїнських змагань; керівництво спортивною делегацією; робота у складі організаційного комітету, суддівського корпусу")]
        public string Num9MangementOfPriceWinnerStudent { get; set; }

        [Display(Name = "Організаційна робота у закладах освіти на посадах керівника (заступника) ВНЗ/факультету/відділення (наукової установи)/ інституту/філії/кафедри або іншого відповідального за підготовку здобувачів ВО підрозділу/відділу (наукової установи)/навчально-методичного управління (відділу)/лабораторії/іншого навчально-наукового (інноваційного) структурного підрозділу/вченого секретаря закладу освіти (факультету, інституту)/відповідального секретаря ПК, його заступника")]
        public string Num10OrganizationalWorkInEducationalInstitutions { get; set; }

        [Display(Name = "Участь в атестації наукових кадрів як офіційного опонента або члена спеціалізованої вченої ради")]
        public string Num11ParticipationInValidationOfScientists { get; set; }

        [Display(Name = "Присудження наукового ступеня доктора наук або присвоєння вченого звання професора")]
        public string Num12DegreeOfDoctor { get; set; }

        [Display(Name = "Наявність авторських свідоцтв та/або патентів загальною кількістю два досягнення")]
        public string Num13PatentsAvailibility { get; set; }

        [Display(Name = "Присудження наукового ступеня доктора філософії або присвоєння вченого звання доцента, або отримання документа про другу вищу освіту")]
        public string Num15DegreeOfDoctorOfPhilosophy { get; set; }

        [Display(Name = "Керівництво студентом, який зайняв призове місце на I етапі Всеукраїнської студентської олімпіади (Всеукраїнського конкурсу студентських наукових робіт), або робота у складі організаційного комітету/журі Всеукраїнської студентської олімпіади (Всеукраїнського конкурсу студентських наукових робіт), або керівництво постійно діючим студентським науковим гуртком/проблемною групою, або виконання обов’язків куратора групи; керівництво студентом, який брав участь в Олімпійських, Паралімпійських іграх, Всесвітній та Всеукраїнській Універсіаді, чемпіонаті світу, Європи, Європейських іграх, етапах Кубку світу та Європи, чемпіонаті України; виконання обов’язків тренера, помічника тренера національної збірної команди  України з видів спорту")]
        public string Num16ManagementOfUkrainianOlympicWinnerStudent { get; set; }

        [Display(Name = "Організація студентської громадської (волонтерської) діяльності, яка має професійне спрямування")]
        public string Num17OrganizingSocialActivities { get; set; }

        [Display(Name = "Поєднання науково-педагогічної роботи та практичної фахової діяльності")]
        public string Num19CombinationOfTeachingAndPractice { get; set; }        
    }
}
