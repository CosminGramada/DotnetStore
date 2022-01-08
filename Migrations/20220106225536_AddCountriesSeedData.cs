using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetStore.Migrations
{
    public partial class AddCountriesSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("32e2ea0a-f103-4d67-8f32-e0c71841541c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5c9b9215-7233-4090-843e-ff801fae31f3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ab534333-ee2b-4891-92d9-980c2e25813e"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00c89937-c3cf-41de-8e8d-d043fa827d29"), "Åland Islands" },
                    { new Guid("00e3f5c6-93d4-4d0f-943a-c3ee2f6297b1"), "Turks & Caicos Islands" },
                    { new Guid("01e78487-fc58-4a12-b18b-24262db2610b"), "San Marino" },
                    { new Guid("01eeb568-aefb-4b38-b20a-8a5d9e5f2e3d"), "Ethiopia" },
                    { new Guid("0337db63-6498-4cbf-aac9-b5c624244afe"), "Slovenia" },
                    { new Guid("04e2c1f3-1c6b-4fa6-837f-0beadde2fc7d"), "Mali" },
                    { new Guid("04e64c6d-e920-420d-b47c-c7c4dc2be4fb"), "Croatia" },
                    { new Guid("050f5dd7-f49c-4e30-b633-9e92fe632156"), "Bermuda" },
                    { new Guid("086ed320-f77e-450e-b850-eeb5c16f338b"), "Guatemala" },
                    { new Guid("0891ebf0-baf1-4df9-b700-eca150795067"), "Vietnam" },
                    { new Guid("0d8b7d79-da31-4952-9aad-ac551a59d260"), "Nauru" },
                    { new Guid("0e0112ac-d35b-4175-9dbc-443626034c28"), "Yemen" },
                    { new Guid("0e7689e6-da83-4bcf-9683-1be70d2c30a6"), "Benin" },
                    { new Guid("1005e705-3392-4b8d-8359-b89e36122735"), "Indonesia" },
                    { new Guid("10c3b512-5192-4ce2-8ff9-9c1da9b0e4f5"), "Georgia" },
                    { new Guid("10d7c30e-813e-4307-89be-cfab52fff2af"), "Brunei" },
                    { new Guid("110b637d-390f-4147-a939-fb8151a57402"), "Oman" },
                    { new Guid("11164fc8-0baf-48a9-a5dd-c6817d7f9bfe"), "Hungary" },
                    { new Guid("146d9945-2c69-477b-9950-9b6d1c109a32"), "Australia" },
                    { new Guid("14939ece-7c0c-4bc9-a6a8-5604925f3df6"), "Cambodia" },
                    { new Guid("14b83869-c01c-4d1f-85ba-9bacdf22f3bb"), "Brazil" },
                    { new Guid("153afaee-89f1-49b9-8fae-b113b026f2b5"), "Lebanon" },
                    { new Guid("1718ff7c-a4f3-4882-9c25-f8819608b1c5"), "Chad" },
                    { new Guid("17c301b8-9bc1-4220-8947-6eb9fd7f405f"), "Argentina" },
                    { new Guid("1ba29009-b3b4-470d-a30c-c1416163489b"), "Iraq" },
                    { new Guid("1dc6c70e-e12c-47b2-902b-b9ffa17dce4a"), "Martinique" },
                    { new Guid("1ea610ce-91cc-4379-a8ae-7bba6c9c16c3"), "Barbados" },
                    { new Guid("1ee005a5-0734-4560-b175-b903c40b5a5e"), "Estonia" },
                    { new Guid("1f1b021b-605a-4ab4-bdf0-bfeeda8462b0"), "Malawi" },
                    { new Guid("1f6fbbca-48bd-44aa-8ff2-94c2068fd445"), "Eritrea" },
                    { new Guid("22f45b8a-c769-4ce4-8bb4-f6a416dc2240"), "Cayman Islands" },
                    { new Guid("245339c1-2862-44ab-8db7-b9a5794049c6"), "Switzerland" },
                    { new Guid("25aa079d-d1d7-4834-8ab2-95c99e736612"), "Ukraine" },
                    { new Guid("2875fc10-9664-484c-8cf6-fffa0b1b3d7c"), "Kenya" },
                    { new Guid("2affa3c6-572e-40df-9b6a-0052e47e82c9"), "Equatorial Guinea" },
                    { new Guid("2bbcb8cb-7a5a-44ef-823d-65f7f85b6b47"), "Western Sahara" },
                    { new Guid("2bfdde11-401b-41a9-8af8-e2476f3c8944"), "Macao SAR" },
                    { new Guid("2c36bcac-760a-4e59-8927-420f241ac14a"), "Cook Islands" },
                    { new Guid("2d6b7160-1796-44b9-a696-e1920d93f346"), "Ireland" },
                    { new Guid("2dad4692-0ce7-4c4e-a3dd-f4dd39ac541e"), "Congo - Kinshasa" },
                    { new Guid("2dfda921-f9a2-4449-aa07-72d0ffe8c463"), "Serbia" },
                    { new Guid("2f049628-c23e-4cd0-95df-5de0524aef0c"), "Bosnia & Herzegovina" },
                    { new Guid("2f11c0e0-3c57-4ea6-970f-7ba9716904e3"), "Mongolia" },
                    { new Guid("3059da70-9cd8-4e2d-98e3-092fbe4754d2"), "Pakistan" },
                    { new Guid("3153e0d5-7247-433e-9c8a-bcf341a34ee5"), "Iceland" },
                    { new Guid("326495bb-1488-48f3-8c18-2cd8cbd3c98d"), "Costa Rica" },
                    { new Guid("34fdf93b-fe57-4d19-b36b-e71cf3752f9c"), "Grenada" },
                    { new Guid("350db462-2695-4f10-9e94-83e60c474a90"), "Egypt" },
                    { new Guid("3620b7f9-dbcc-405d-87bb-a15cae7f2ee4"), "Qatar" },
                    { new Guid("3733b688-858e-40ac-a4e8-efca9d738132"), "Algeria" },
                    { new Guid("39654c0b-4e6d-437f-97fa-aa55d74ea710"), "Portugal" },
                    { new Guid("39db7626-7f48-4136-924c-05643c9969c9"), "Niger" },
                    { new Guid("3ce166b2-80cf-43da-87c2-8b5c2d5ee9fc"), "Germany" },
                    { new Guid("3d64054d-5d3a-4a15-9790-4bb72e6eba2b"), "Solomon Islands" },
                    { new Guid("3e061180-aff9-4d03-b0d4-8b23bf29a053"), "Norway" },
                    { new Guid("3fe67f40-f2c1-40fa-bfa6-0a76dffb714f"), "United States" },
                    { new Guid("4048f6c8-f734-4600-87e7-f7cf4399f2c9"), "British Indian Ocean Territory" },
                    { new Guid("42473a18-e781-4787-aa66-b438410d2305"), "South Sudan" },
                    { new Guid("425cd588-aa02-4f0a-b358-5438dd1ac1f4"), "Djibouti" },
                    { new Guid("4294d008-5164-480c-92e0-552a3c19a8e2"), "Sweden" },
                    { new Guid("4334eecf-da69-4c66-a1b9-9718c720d7e1"), "Thailand" },
                    { new Guid("43a25128-9e78-41ba-ba20-a7f2ab9f6be7"), "Aruba" },
                    { new Guid("46310607-8bc6-4b45-8b17-6e25c2fa9e6c"), "U.S. Outlying Islands" },
                    { new Guid("4730724a-af67-4276-a19f-de2e50b7cfcf"), "Belgium" },
                    { new Guid("4895c19c-4ba9-4347-a7f9-585ba8d515ed"), "Réunion" },
                    { new Guid("4a12724f-c780-48d5-a100-052e74475a85"), "Cyprus" },
                    { new Guid("4acabe60-63d5-43f4-aebe-348108708544"), "Israel" },
                    { new Guid("4c354fc6-50b1-4f83-a8b3-e42412ab490d"), "Vatican City" },
                    { new Guid("4e5fe40c-d3a2-4c97-aa8b-76fb14fce5b9"), "Guadeloupe" },
                    { new Guid("4f19c870-06d4-4333-9881-c54bd1b70296"), "St. Helena" },
                    { new Guid("50653a27-905c-4e63-add2-bfd2e632abd8"), "Guinea-Bissau" },
                    { new Guid("513e03ec-fd15-4049-98eb-78b80f2840c1"), "Malaysia" },
                    { new Guid("51d4ac33-744c-4baf-b321-6a5327f24b3c"), "Spain" },
                    { new Guid("520f9813-184c-4292-ae69-bec5746dd93e"), "Belarus" },
                    { new Guid("5238c4c3-f231-4c82-b99f-aae3f391b29d"), "Morocco" },
                    { new Guid("531d43e4-7c77-44df-b209-6a54c13bee86"), "South Africa" },
                    { new Guid("54895fed-3e01-4440-b0d2-74c1f89f7206"), "Venezuela" },
                    { new Guid("54f06d3c-ee25-4489-88a9-9f9fd84b9638"), "Sri Lanka" },
                    { new Guid("552d89ef-cd8e-4360-9487-17c5fad2416b"), "St. Vincent & Grenadines" },
                    { new Guid("5547745c-cef8-41e1-bc35-93e8d6fe33ba"), "Monaco" },
                    { new Guid("55b828aa-987f-4e70-a6bc-490439d60822"), "Sint Maarten" },
                    { new Guid("56226f3e-e53d-4b07-b1c6-a03d56895653"), "Isle of Man" },
                    { new Guid("56a8ac24-4dbe-439f-b6a8-159589b9a612"), "Congo - Brazzaville" },
                    { new Guid("5d8b7189-2858-4661-964e-d66d91ffbb0c"), "Myanmar (Burma)" },
                    { new Guid("5d965a66-fe12-4535-99f3-e7f22487f3a5"), "Kyrgyzstan" },
                    { new Guid("5fd2d806-f721-474c-b244-af4a560d4d9b"), "Nepal" },
                    { new Guid("5fd54e05-d1ad-4fab-8cde-ea87360db83e"), "Rwanda" },
                    { new Guid("619c10a0-89b5-421a-81c0-f2078291c86a"), "Uzbekistan" },
                    { new Guid("6205b2af-2d51-4ec5-bef0-701338d4a83d"), "Azerbaijan" },
                    { new Guid("623c9753-eb23-4483-99b3-cc935aa620cf"), "Finland" },
                    { new Guid("64a7009f-88c3-42b9-8b14-07543fc0f1c9"), "Austria" },
                    { new Guid("655b8d47-7d7b-411c-bebe-a27358a93dfe"), "Guinea" },
                    { new Guid("658e69a3-d19f-4928-ad38-4a9749377fa0"), "Canada" },
                    { new Guid("65d0335a-d227-448b-bee4-68b185823223"), "French Guiana" },
                    { new Guid("66113555-5570-40a9-b091-578439a406fb"), "Tunisia" },
                    { new Guid("675336ca-40c5-4135-85a5-f252dbeeba6e"), "Anguilla" },
                    { new Guid("682d0f73-cd6c-4df7-a73b-beda07575d63"), "South Korea" },
                    { new Guid("69f20c84-a8f5-42fe-a6b4-1e1746d5f97b"), "Pitcairn Islands" },
                    { new Guid("6a04cb70-676b-4d9b-9765-8ee3815ab599"), "Antigua & Barbuda" },
                    { new Guid("6a377230-e9f2-496a-8252-d0172ab294b7"), "Montenegro" },
                    { new Guid("6a96d017-4298-4560-a928-0677c7dee3b9"), "Svalbard & Jan Mayen" },
                    { new Guid("6c4af999-2222-4415-a918-6be5e68ee8db"), "Liberia" },
                    { new Guid("6c91b04f-28e0-4bee-8a21-674ce7c7c4a3"), "Guernsey" },
                    { new Guid("6cd1264e-3b9f-42a6-86cc-2b9cfd09221d"), "Comoros" },
                    { new Guid("70cfcf8c-a36e-4dd8-8e35-b3e1997711ae"), "Bangladesh" },
                    { new Guid("7136b77f-186c-4cfd-a76b-cce78abf96d0"), "Laos" },
                    { new Guid("7250b096-aa86-4c72-824f-00794fea6f1e"), "Jamaica" },
                    { new Guid("7254a6bf-9645-4c35-b1fc-361c5732145b"), "Zambia" },
                    { new Guid("72ee1970-3adb-42b3-8383-189e3a47b15a"), "Burundi" },
                    { new Guid("73a9f36b-8a7c-47f5-9e70-61004c0a52ca"), "Suriname" },
                    { new Guid("73ad557e-994d-4e96-992e-c6320dc08892"), "China" },
                    { new Guid("741e1a2d-70dc-4600-a602-c63d49621645"), "Philippines" },
                    { new Guid("744f333b-127d-4aeb-9b75-841ad3ab6fed"), "Jordan" },
                    { new Guid("74c53214-5c0a-4c4b-800a-e0afbc85fbf2"), "Kosovo" },
                    { new Guid("75032198-137a-4a58-bf97-58ab690deaa5"), "Trinidad & Tobago" },
                    { new Guid("764d816f-ac41-4ab5-a1fe-33a2c542e0ec"), "Libya" },
                    { new Guid("78e80316-04c1-414b-be00-9ec3e8a46786"), "Latvia" },
                    { new Guid("79002fb4-f346-4df6-a690-2d0fdd8e9689"), "Liechtenstein" },
                    { new Guid("79925a6f-916d-4ae5-8613-a61ab8f3d0d1"), "North Macedonia" },
                    { new Guid("7beb3843-a7ca-4b68-b2d3-c910d19435ab"), "Gibraltar" },
                    { new Guid("7befd5c6-c616-4d61-8cc7-237d8db1121a"), "Samoa" },
                    { new Guid("7c5e8b8b-020a-4c2e-809e-41a39da4766d"), "Turkmenistan" },
                    { new Guid("7e9faabe-1a44-41d6-a06d-fc465817010b"), "Jersey" },
                    { new Guid("7eee547e-32da-41fe-bb83-082cb9867a39"), "St. Kitts & Nevis" },
                    { new Guid("7fdeb9e0-9557-4229-903f-166788dd0199"), "Panama" },
                    { new Guid("843387a2-766a-4d4d-a0ea-7ff144b98989"), "Chile" },
                    { new Guid("864f39d6-ba28-42c4-9016-4cf29878945e"), "Christmas Island" },
                    { new Guid("871c70a0-88d7-4b14-a8f3-6bbfd384c796"), "Vanuatu" },
                    { new Guid("8a78592a-739b-45fd-a5ae-9d2d55fcf13a"), "Nigeria" },
                    { new Guid("8b44e713-dc6f-4573-8a16-8e916a5f6119"), "Tuvalu" },
                    { new Guid("8c3628e0-28d2-4321-a17a-a58ce86fb010"), "South Georgia & South Sandwich Islands" },
                    { new Guid("8e5b599d-20c0-40d5-bd6c-bbb399c9cc5d"), "Cape Verde" },
                    { new Guid("8f0312a0-e65b-4011-82c2-4e4612eb4214"), "Tristan da Cunha" },
                    { new Guid("8f3e7de8-deee-47ec-9916-7d28fd0e78a7"), "Ascension Island" },
                    { new Guid("905530b0-6ab7-4423-a631-c136a6f0934a"), "India" },
                    { new Guid("9082958f-9303-43f8-8a78-16ae378770fd"), "Côte d’Ivoire" },
                    { new Guid("92543a15-0e86-4a8e-8543-82f7a0c19a1b"), "Curaçao" },
                    { new Guid("95c8aaca-1eb5-4c18-aad8-6a663dc8daba"), "Moldova" },
                    { new Guid("963f5d46-f303-4e90-85cd-586268d00bbc"), "Belize" },
                    { new Guid("9c709236-7036-4594-b3c9-e9ea0bce3fba"), "Timor-Leste" },
                    { new Guid("9d83fe43-8711-4d43-a057-606d0041655f"), "Caribbean Netherlands" },
                    { new Guid("9eb63314-290f-4904-9195-4225bc6f9561"), "Taiwan" },
                    { new Guid("9f72fbbe-967e-4096-a7b9-7677733be443"), "Slovakia" },
                    { new Guid("a0c38375-f691-44eb-9ee2-f0a1a3d16530"), "Namibia" },
                    { new Guid("a0eca863-6de1-4627-8c17-00f01886ede2"), "Papua New Guinea" },
                    { new Guid("a3bb40f0-faf1-4a73-bc62-a3df2555c427"), "Luxembourg" },
                    { new Guid("a3c99401-70c0-434c-8177-49e1b613304b"), "Mauritania" },
                    { new Guid("a44c5f79-6da2-4e18-af8b-f59a95cf35f2"), "Montserrat" },
                    { new Guid("a7069e9c-9045-413c-80f8-b73f44abd748"), "Seychelles" },
                    { new Guid("a84bda95-b72b-4d6f-a1be-26b8b133e594"), "Gambia" },
                    { new Guid("a9a5d9c4-e3cf-49e0-8971-873596875d08"), "Paraguay" },
                    { new Guid("ab23ca55-721b-4e13-9378-c68444e8410c"), "Bahamas" },
                    { new Guid("ac6ea3cf-784d-4d30-8549-a13c11626a27"), "Ecuador" },
                    { new Guid("ae0744f4-dafe-4c08-845f-05723facb48a"), "Sierra Leone" },
                    { new Guid("ae824a9f-86a9-46ba-8788-27c00203acfd"), "St. Lucia" },
                    { new Guid("af5800c3-016d-4ed3-aa02-667b0650c583"), "Haiti" },
                    { new Guid("b049386f-affe-4367-8aea-152d3d3b1979"), "Palestinian Territories" },
                    { new Guid("b0e323ee-2960-4ac3-8d2f-fc740bd36295"), "Malta" },
                    { new Guid("b10482e9-eda0-480c-b946-96b7b292a1d5"), "Kazakhstan" },
                    { new Guid("b17a5cba-686d-4b7c-ac6c-f10fd710ce61"), "Greece" },
                    { new Guid("b1d2cbc1-bfb5-47ae-9071-a71ee90207b2"), "United Kingdom" },
                    { new Guid("b371e846-abb6-44df-a15f-655bd7fce401"), "Albania" },
                    { new Guid("b3861c75-7836-4f14-95f9-c02266f067f1"), "Tajikistan" },
                    { new Guid("b39ffe31-dd69-4f0b-b94a-16d5cadb456b"), "British Virgin Islands" },
                    { new Guid("b5609d6f-b7ec-4122-977e-0ee33f4cc4f2"), "Falkland Islands" },
                    { new Guid("b6560646-e7ea-459a-9718-465ae1ea7953"), "Niue" },
                    { new Guid("b65726ea-b109-4355-ba49-e1c4f2753177"), "Somalia" },
                    { new Guid("b6b8dcfe-ad7a-494b-ab33-03b84f8521df"), "France" },
                    { new Guid("b792e273-16ef-4411-bf0e-dd1535b379d3"), "Wallis & Futuna" },
                    { new Guid("b8473c64-c52d-46fb-ad2a-88a8bf751616"), "Mexico" },
                    { new Guid("b8af39a6-ad3e-413f-af6f-e8288b17b16d"), "Nicaragua" },
                    { new Guid("bafc1200-16e8-414b-ba35-10f39b80b24a"), "Poland" },
                    { new Guid("bb72733a-051f-4db7-a40a-f87492bd582d"), "Faroe Islands" },
                    { new Guid("bc9ad3f3-01f4-4978-9a80-3506eae18472"), "French Polynesia" },
                    { new Guid("bd7ab324-f34d-4586-a813-bc8735a1abd2"), "St. Pierre & Miquelon" },
                    { new Guid("be049a72-8e9b-46d0-9148-f1969b5add30"), "Togo" },
                    { new Guid("bf3bfc06-7486-43fc-b7e5-dd4c4ae5f474"), "Angola" },
                    { new Guid("bfd6955f-a367-4bfd-a5ab-85bfe0de4a13"), "Tokelau" },
                    { new Guid("c1e0f5e6-1c11-491e-a7d4-a6caed4d25b6"), "Madagascar" },
                    { new Guid("c1ec5f52-e491-48a2-9ba1-49e8ee783247"), "Tanzania" },
                    { new Guid("c4f73e5e-9ee6-47ff-8aaf-2c27b174e8b4"), "Denmark" },
                    { new Guid("c611af37-7533-41a0-9818-d8422c32d6ec"), "Botswana" },
                    { new Guid("c7824a68-83d3-4008-a8c3-27d1b94c5c1d"), "Cocos (Keeling) Islands" },
                    { new Guid("c86e16cb-1c56-4268-baab-fcf6d0201e25"), "Lesotho" },
                    { new Guid("cb247e3e-5453-40e1-9cee-7a93031f6a35"), "Gabon" },
                    { new Guid("cbfd849c-17a0-4a7f-82c3-6720afb2c64e"), "Dominica" },
                    { new Guid("cc49a050-3961-4ab9-90a3-c1e78e785f2e"), "Bolivia" },
                    { new Guid("cd00e532-87cf-4b1c-8468-c7bd91e9457b"), "New Caledonia" },
                    { new Guid("d00dbd74-9f7a-466b-9cf0-efdeb8c080ce"), "Singapore" },
                    { new Guid("d1159ea5-e537-48df-ab4e-393a7f39d652"), "New Zealand" },
                    { new Guid("d1672445-f6bf-42b5-acae-86ffdd1377df"), "St. Barthélemy" },
                    { new Guid("d1835df3-09be-4812-9915-91c0a4dc7719"), "Sudan" },
                    { new Guid("d2271384-059f-4e6e-be1e-2db6d6681f06"), "Ghana" },
                    { new Guid("d3876397-54f8-47c4-920b-06f2f2edb6ab"), "Russia" },
                    { new Guid("d425b3f0-468e-49cf-bda2-69b3577a1728"), "Dominican Republic" },
                    { new Guid("d498cbec-9982-47a3-aaab-b3195064527c"), "United Arab Emirates" },
                    { new Guid("d56e8115-c228-4819-98ba-84012d378520"), "Honduras" },
                    { new Guid("d7077202-41d8-451d-aff5-e926a27970af"), "Lithuania" },
                    { new Guid("d7cefdb1-a4af-4dcb-8df8-84a8b071fc90"), "Czechia" },
                    { new Guid("d9585f81-5726-49c4-9802-4e3c37b3050f"), "Eswatini" },
                    { new Guid("da41ac07-a2a7-40f6-aeb6-953ef305180e"), "Uruguay" },
                    { new Guid("dc509335-e9c1-4162-9130-105286b2e9ef"), "Armenia" },
                    { new Guid("de971f98-d3c7-4fed-b821-02f22155f32c"), "Guyana" },
                    { new Guid("df4ef662-5ea5-45cd-b431-6e2182ac1980"), "Netherlands" },
                    { new Guid("e1fd2f53-66cf-4883-b0e8-03967178786a"), "St. Martin" },
                    { new Guid("e302c62c-48f5-4224-932a-5d76401fd3d1"), "Bulgaria" },
                    { new Guid("e30db5e6-a417-4864-93fa-16c9c8a3db86"), "Turkey" },
                    { new Guid("e336d93e-9be7-4653-b5ae-9ed879eb2024"), "Fiji" },
                    { new Guid("e3b212d9-8ca3-4cd3-88c7-a9de3dfe22f2"), "Mayotte" },
                    { new Guid("e540d79b-ed23-4e3f-8f9d-c5212c6029f7"), "Uganda" },
                    { new Guid("e7fe6218-4e75-441c-94c3-20c595b5d76a"), "Bhutan" },
                    { new Guid("e8a904a1-3a69-4ee9-aad5-cab984a9868d"), "Bahrain" },
                    { new Guid("e93383fa-6f2d-46db-8d12-77fda4f544b0"), "Kiribati" },
                    { new Guid("e9f9cb1c-ce37-49e6-9a86-805adfd4d2c1"), "Andorra" },
                    { new Guid("ec5280ec-295f-469a-a374-39c66de930e3"), "Saudi Arabia" },
                    { new Guid("ec75157b-12c3-45bb-ae4b-cf122d045fe9"), "Mauritius" },
                    { new Guid("edd5ae24-c772-4e12-b6b6-58c80411862a"), "Tonga" },
                    { new Guid("ee30388a-4f3e-4692-a1b4-4204e84d9530"), "Mozambique" },
                    { new Guid("ee8c90fe-281c-409e-abbc-79e8e943bb4e"), "Senegal" },
                    { new Guid("eea2d7ff-ec84-41f5-bab6-5c07fe14fea5"), "Cameroon" },
                    { new Guid("ef1eac36-31af-4b45-aa73-619d8bfd52df"), "Japan" },
                    { new Guid("efc6df51-1330-4bb4-b83c-b9dce65e7332"), "Zimbabwe" },
                    { new Guid("f0f872c2-b6cb-4bd1-9f83-20c16f5667dc"), "French Southern Territories" },
                    { new Guid("f22aad98-b8c5-4640-9a49-327565d1cfcc"), "Peru" },
                    { new Guid("f23e873e-f708-43fd-85c3-968730dc4204"), "El Salvador" },
                    { new Guid("f396183d-d234-480e-9b67-323fd21f4433"), "Norfolk Island" },
                    { new Guid("f498f09e-6ed9-496d-818e-0acb9e526deb"), "São Tomé & Príncipe" },
                    { new Guid("f52ebc0d-0ce4-4803-b2ab-b3955405d9fb"), "Kuwait" },
                    { new Guid("f52faef9-5f48-4428-b642-a5c5299a37d4"), "Italy" },
                    { new Guid("f956976d-f54a-40c7-9c29-4761b402349b"), "Hong Kong SAR" },
                    { new Guid("fa45fc44-3a86-4180-b8c4-352c8a403617"), "Greenland" },
                    { new Guid("fb2c9da3-7fef-47f5-871c-8f1705c7d6f3"), "Maldives" },
                    { new Guid("fb7fc57d-b913-404c-bd21-c4eb6f7d0ec8"), "Central African Republic" },
                    { new Guid("fcd814b4-38d9-4dc4-a681-30496e1fcd64"), "Burkina Faso" },
                    { new Guid("fe06410b-4872-4891-a5d0-630fba46cd9f"), "Colombia" },
                    { new Guid("fef0d8fa-1ade-41f3-bff7-b2cb216fe6eb"), "Romania" },
                    { new Guid("ff104342-c211-4ce1-bba3-6607db0430fc"), "Afghanistan" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00c89937-c3cf-41de-8e8d-d043fa827d29"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00e3f5c6-93d4-4d0f-943a-c3ee2f6297b1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("01e78487-fc58-4a12-b18b-24262db2610b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("01eeb568-aefb-4b38-b20a-8a5d9e5f2e3d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0337db63-6498-4cbf-aac9-b5c624244afe"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("04e2c1f3-1c6b-4fa6-837f-0beadde2fc7d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("04e64c6d-e920-420d-b47c-c7c4dc2be4fb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("050f5dd7-f49c-4e30-b633-9e92fe632156"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("086ed320-f77e-450e-b850-eeb5c16f338b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0891ebf0-baf1-4df9-b700-eca150795067"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0d8b7d79-da31-4952-9aad-ac551a59d260"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0e0112ac-d35b-4175-9dbc-443626034c28"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0e7689e6-da83-4bcf-9683-1be70d2c30a6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1005e705-3392-4b8d-8359-b89e36122735"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("10c3b512-5192-4ce2-8ff9-9c1da9b0e4f5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("10d7c30e-813e-4307-89be-cfab52fff2af"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("110b637d-390f-4147-a939-fb8151a57402"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("11164fc8-0baf-48a9-a5dd-c6817d7f9bfe"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("146d9945-2c69-477b-9950-9b6d1c109a32"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("14939ece-7c0c-4bc9-a6a8-5604925f3df6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("14b83869-c01c-4d1f-85ba-9bacdf22f3bb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("153afaee-89f1-49b9-8fae-b113b026f2b5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1718ff7c-a4f3-4882-9c25-f8819608b1c5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("17c301b8-9bc1-4220-8947-6eb9fd7f405f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1ba29009-b3b4-470d-a30c-c1416163489b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1dc6c70e-e12c-47b2-902b-b9ffa17dce4a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1ea610ce-91cc-4379-a8ae-7bba6c9c16c3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1ee005a5-0734-4560-b175-b903c40b5a5e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1f1b021b-605a-4ab4-bdf0-bfeeda8462b0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1f6fbbca-48bd-44aa-8ff2-94c2068fd445"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("22f45b8a-c769-4ce4-8bb4-f6a416dc2240"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("245339c1-2862-44ab-8db7-b9a5794049c6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("25aa079d-d1d7-4834-8ab2-95c99e736612"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2875fc10-9664-484c-8cf6-fffa0b1b3d7c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2affa3c6-572e-40df-9b6a-0052e47e82c9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2bbcb8cb-7a5a-44ef-823d-65f7f85b6b47"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2bfdde11-401b-41a9-8af8-e2476f3c8944"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2c36bcac-760a-4e59-8927-420f241ac14a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2d6b7160-1796-44b9-a696-e1920d93f346"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2dad4692-0ce7-4c4e-a3dd-f4dd39ac541e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2dfda921-f9a2-4449-aa07-72d0ffe8c463"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2f049628-c23e-4cd0-95df-5de0524aef0c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2f11c0e0-3c57-4ea6-970f-7ba9716904e3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3059da70-9cd8-4e2d-98e3-092fbe4754d2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3153e0d5-7247-433e-9c8a-bcf341a34ee5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("326495bb-1488-48f3-8c18-2cd8cbd3c98d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("34fdf93b-fe57-4d19-b36b-e71cf3752f9c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("350db462-2695-4f10-9e94-83e60c474a90"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3620b7f9-dbcc-405d-87bb-a15cae7f2ee4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3733b688-858e-40ac-a4e8-efca9d738132"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("39654c0b-4e6d-437f-97fa-aa55d74ea710"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("39db7626-7f48-4136-924c-05643c9969c9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3ce166b2-80cf-43da-87c2-8b5c2d5ee9fc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3d64054d-5d3a-4a15-9790-4bb72e6eba2b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3e061180-aff9-4d03-b0d4-8b23bf29a053"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3fe67f40-f2c1-40fa-bfa6-0a76dffb714f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4048f6c8-f734-4600-87e7-f7cf4399f2c9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("42473a18-e781-4787-aa66-b438410d2305"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("425cd588-aa02-4f0a-b358-5438dd1ac1f4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4294d008-5164-480c-92e0-552a3c19a8e2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4334eecf-da69-4c66-a1b9-9718c720d7e1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("43a25128-9e78-41ba-ba20-a7f2ab9f6be7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("46310607-8bc6-4b45-8b17-6e25c2fa9e6c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4730724a-af67-4276-a19f-de2e50b7cfcf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4895c19c-4ba9-4347-a7f9-585ba8d515ed"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4a12724f-c780-48d5-a100-052e74475a85"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4acabe60-63d5-43f4-aebe-348108708544"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4c354fc6-50b1-4f83-a8b3-e42412ab490d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4e5fe40c-d3a2-4c97-aa8b-76fb14fce5b9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4f19c870-06d4-4333-9881-c54bd1b70296"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("50653a27-905c-4e63-add2-bfd2e632abd8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("513e03ec-fd15-4049-98eb-78b80f2840c1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("51d4ac33-744c-4baf-b321-6a5327f24b3c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("520f9813-184c-4292-ae69-bec5746dd93e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5238c4c3-f231-4c82-b99f-aae3f391b29d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("531d43e4-7c77-44df-b209-6a54c13bee86"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("54895fed-3e01-4440-b0d2-74c1f89f7206"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("54f06d3c-ee25-4489-88a9-9f9fd84b9638"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("552d89ef-cd8e-4360-9487-17c5fad2416b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5547745c-cef8-41e1-bc35-93e8d6fe33ba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("55b828aa-987f-4e70-a6bc-490439d60822"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("56226f3e-e53d-4b07-b1c6-a03d56895653"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("56a8ac24-4dbe-439f-b6a8-159589b9a612"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5d8b7189-2858-4661-964e-d66d91ffbb0c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5d965a66-fe12-4535-99f3-e7f22487f3a5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5fd2d806-f721-474c-b244-af4a560d4d9b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5fd54e05-d1ad-4fab-8cde-ea87360db83e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("619c10a0-89b5-421a-81c0-f2078291c86a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6205b2af-2d51-4ec5-bef0-701338d4a83d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("623c9753-eb23-4483-99b3-cc935aa620cf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("64a7009f-88c3-42b9-8b14-07543fc0f1c9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("655b8d47-7d7b-411c-bebe-a27358a93dfe"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("658e69a3-d19f-4928-ad38-4a9749377fa0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("65d0335a-d227-448b-bee4-68b185823223"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("66113555-5570-40a9-b091-578439a406fb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("675336ca-40c5-4135-85a5-f252dbeeba6e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("682d0f73-cd6c-4df7-a73b-beda07575d63"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("69f20c84-a8f5-42fe-a6b4-1e1746d5f97b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6a04cb70-676b-4d9b-9765-8ee3815ab599"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6a377230-e9f2-496a-8252-d0172ab294b7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6a96d017-4298-4560-a928-0677c7dee3b9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6c4af999-2222-4415-a918-6be5e68ee8db"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6c91b04f-28e0-4bee-8a21-674ce7c7c4a3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6cd1264e-3b9f-42a6-86cc-2b9cfd09221d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("70cfcf8c-a36e-4dd8-8e35-b3e1997711ae"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7136b77f-186c-4cfd-a76b-cce78abf96d0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7250b096-aa86-4c72-824f-00794fea6f1e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7254a6bf-9645-4c35-b1fc-361c5732145b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("72ee1970-3adb-42b3-8383-189e3a47b15a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("73a9f36b-8a7c-47f5-9e70-61004c0a52ca"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("73ad557e-994d-4e96-992e-c6320dc08892"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("741e1a2d-70dc-4600-a602-c63d49621645"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("744f333b-127d-4aeb-9b75-841ad3ab6fed"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("74c53214-5c0a-4c4b-800a-e0afbc85fbf2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("75032198-137a-4a58-bf97-58ab690deaa5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("764d816f-ac41-4ab5-a1fe-33a2c542e0ec"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("78e80316-04c1-414b-be00-9ec3e8a46786"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("79002fb4-f346-4df6-a690-2d0fdd8e9689"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("79925a6f-916d-4ae5-8613-a61ab8f3d0d1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7beb3843-a7ca-4b68-b2d3-c910d19435ab"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7befd5c6-c616-4d61-8cc7-237d8db1121a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7c5e8b8b-020a-4c2e-809e-41a39da4766d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7e9faabe-1a44-41d6-a06d-fc465817010b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7eee547e-32da-41fe-bb83-082cb9867a39"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7fdeb9e0-9557-4229-903f-166788dd0199"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("843387a2-766a-4d4d-a0ea-7ff144b98989"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("864f39d6-ba28-42c4-9016-4cf29878945e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("871c70a0-88d7-4b14-a8f3-6bbfd384c796"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8a78592a-739b-45fd-a5ae-9d2d55fcf13a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8b44e713-dc6f-4573-8a16-8e916a5f6119"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c3628e0-28d2-4321-a17a-a58ce86fb010"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8e5b599d-20c0-40d5-bd6c-bbb399c9cc5d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8f0312a0-e65b-4011-82c2-4e4612eb4214"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8f3e7de8-deee-47ec-9916-7d28fd0e78a7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("905530b0-6ab7-4423-a631-c136a6f0934a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9082958f-9303-43f8-8a78-16ae378770fd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("92543a15-0e86-4a8e-8543-82f7a0c19a1b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("95c8aaca-1eb5-4c18-aad8-6a663dc8daba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("963f5d46-f303-4e90-85cd-586268d00bbc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9c709236-7036-4594-b3c9-e9ea0bce3fba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9d83fe43-8711-4d43-a057-606d0041655f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9eb63314-290f-4904-9195-4225bc6f9561"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9f72fbbe-967e-4096-a7b9-7677733be443"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a0c38375-f691-44eb-9ee2-f0a1a3d16530"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a0eca863-6de1-4627-8c17-00f01886ede2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a3bb40f0-faf1-4a73-bc62-a3df2555c427"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a3c99401-70c0-434c-8177-49e1b613304b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a44c5f79-6da2-4e18-af8b-f59a95cf35f2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a7069e9c-9045-413c-80f8-b73f44abd748"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a84bda95-b72b-4d6f-a1be-26b8b133e594"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a9a5d9c4-e3cf-49e0-8971-873596875d08"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ab23ca55-721b-4e13-9378-c68444e8410c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ac6ea3cf-784d-4d30-8549-a13c11626a27"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ae0744f4-dafe-4c08-845f-05723facb48a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ae824a9f-86a9-46ba-8788-27c00203acfd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("af5800c3-016d-4ed3-aa02-667b0650c583"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b049386f-affe-4367-8aea-152d3d3b1979"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b0e323ee-2960-4ac3-8d2f-fc740bd36295"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b10482e9-eda0-480c-b946-96b7b292a1d5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b17a5cba-686d-4b7c-ac6c-f10fd710ce61"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b1d2cbc1-bfb5-47ae-9071-a71ee90207b2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b371e846-abb6-44df-a15f-655bd7fce401"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b3861c75-7836-4f14-95f9-c02266f067f1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b39ffe31-dd69-4f0b-b94a-16d5cadb456b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b5609d6f-b7ec-4122-977e-0ee33f4cc4f2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b6560646-e7ea-459a-9718-465ae1ea7953"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b65726ea-b109-4355-ba49-e1c4f2753177"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b6b8dcfe-ad7a-494b-ab33-03b84f8521df"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b792e273-16ef-4411-bf0e-dd1535b379d3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b8473c64-c52d-46fb-ad2a-88a8bf751616"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b8af39a6-ad3e-413f-af6f-e8288b17b16d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bafc1200-16e8-414b-ba35-10f39b80b24a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bb72733a-051f-4db7-a40a-f87492bd582d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bc9ad3f3-01f4-4978-9a80-3506eae18472"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bd7ab324-f34d-4586-a813-bc8735a1abd2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("be049a72-8e9b-46d0-9148-f1969b5add30"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bf3bfc06-7486-43fc-b7e5-dd4c4ae5f474"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bfd6955f-a367-4bfd-a5ab-85bfe0de4a13"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c1e0f5e6-1c11-491e-a7d4-a6caed4d25b6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c1ec5f52-e491-48a2-9ba1-49e8ee783247"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c4f73e5e-9ee6-47ff-8aaf-2c27b174e8b4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c611af37-7533-41a0-9818-d8422c32d6ec"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c7824a68-83d3-4008-a8c3-27d1b94c5c1d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c86e16cb-1c56-4268-baab-fcf6d0201e25"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cb247e3e-5453-40e1-9cee-7a93031f6a35"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cbfd849c-17a0-4a7f-82c3-6720afb2c64e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cc49a050-3961-4ab9-90a3-c1e78e785f2e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cd00e532-87cf-4b1c-8468-c7bd91e9457b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d00dbd74-9f7a-466b-9cf0-efdeb8c080ce"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d1159ea5-e537-48df-ab4e-393a7f39d652"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d1672445-f6bf-42b5-acae-86ffdd1377df"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d1835df3-09be-4812-9915-91c0a4dc7719"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d2271384-059f-4e6e-be1e-2db6d6681f06"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d3876397-54f8-47c4-920b-06f2f2edb6ab"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d425b3f0-468e-49cf-bda2-69b3577a1728"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d498cbec-9982-47a3-aaab-b3195064527c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d56e8115-c228-4819-98ba-84012d378520"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d7077202-41d8-451d-aff5-e926a27970af"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d7cefdb1-a4af-4dcb-8df8-84a8b071fc90"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d9585f81-5726-49c4-9802-4e3c37b3050f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("da41ac07-a2a7-40f6-aeb6-953ef305180e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("dc509335-e9c1-4162-9130-105286b2e9ef"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("de971f98-d3c7-4fed-b821-02f22155f32c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("df4ef662-5ea5-45cd-b431-6e2182ac1980"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e1fd2f53-66cf-4883-b0e8-03967178786a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e302c62c-48f5-4224-932a-5d76401fd3d1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e30db5e6-a417-4864-93fa-16c9c8a3db86"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e336d93e-9be7-4653-b5ae-9ed879eb2024"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e3b212d9-8ca3-4cd3-88c7-a9de3dfe22f2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e540d79b-ed23-4e3f-8f9d-c5212c6029f7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e7fe6218-4e75-441c-94c3-20c595b5d76a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e8a904a1-3a69-4ee9-aad5-cab984a9868d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e93383fa-6f2d-46db-8d12-77fda4f544b0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e9f9cb1c-ce37-49e6-9a86-805adfd4d2c1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ec5280ec-295f-469a-a374-39c66de930e3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ec75157b-12c3-45bb-ae4b-cf122d045fe9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("edd5ae24-c772-4e12-b6b6-58c80411862a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ee30388a-4f3e-4692-a1b4-4204e84d9530"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ee8c90fe-281c-409e-abbc-79e8e943bb4e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("eea2d7ff-ec84-41f5-bab6-5c07fe14fea5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ef1eac36-31af-4b45-aa73-619d8bfd52df"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("efc6df51-1330-4bb4-b83c-b9dce65e7332"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f0f872c2-b6cb-4bd1-9f83-20c16f5667dc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f22aad98-b8c5-4640-9a49-327565d1cfcc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f23e873e-f708-43fd-85c3-968730dc4204"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f396183d-d234-480e-9b67-323fd21f4433"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f498f09e-6ed9-496d-818e-0acb9e526deb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f52ebc0d-0ce4-4803-b2ab-b3955405d9fb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f52faef9-5f48-4428-b642-a5c5299a37d4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f956976d-f54a-40c7-9c29-4761b402349b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fa45fc44-3a86-4180-b8c4-352c8a403617"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fb2c9da3-7fef-47f5-871c-8f1705c7d6f3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fb7fc57d-b913-404c-bd21-c4eb6f7d0ec8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fcd814b4-38d9-4dc4-a681-30496e1fcd64"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fe06410b-4872-4891-a5d0-630fba46cd9f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fef0d8fa-1ade-41f3-bff7-b2cb216fe6eb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ff104342-c211-4ce1-bba3-6607db0430fc"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("32e2ea0a-f103-4d67-8f32-e0c71841541c"), "Test" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5c9b9215-7233-4090-843e-ff801fae31f3"), "Test2" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ab534333-ee2b-4891-92d9-980c2e25813e"), "Test1" });
        }
    }
}
