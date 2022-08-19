# SalesOfFlats
Project created as part of learning how to create WEB APIs, taking into account good practices and principles of correct architecture of this type of application

**The following functionalities were implemented as part of the project:**
- possibility to add a new housing announcement (with validation of selected fields
- functionality of pagination and sorting of results according to selected parameter values
- editing an existing housing announcement 
- possibility of deleting a selected announcement 
- functionality of adding pictures to the server
- functionality of adding files to the server
- NLog data logging
- application testing using unit tests and integration tests

-------------------------------------------------------------------------

Initially, the database did not contain any records. After attempting to return housing data using the /api/Flats endpoint, the result was:

![wynik wyszukiwania](https://user-images.githubusercontent.com/62789906/185596578-bc4f0f69-58ec-48bf-b1e2-a1db0b3a7ba4.png)

Using the endpoint /api/Flats (POST), a flat containing the correct data was added. The result of this request can be seen in the illustration:

![dodanie poprawnego mieszkania](https://user-images.githubusercontent.com/62789906/185597053-d6f457c8-4ec8-4497-901c-e171c474c37c.png)

Attempts to add a flat with incorrect data (empty title or description, numerical values less than or equal to 0) will fail. A properly wrapped HTTP 400 error will be returned.

![próba dodania mieszkania z niepoprawnymi danymi](https://user-images.githubusercontent.com/62789906/185597408-e8506f67-d3f3-44b3-908a-ee2ce483f094.png)

An attempt to search for an added flat by ID is successful. The relevant data is displayed:

![szukanie mieszkania po ID](https://user-images.githubusercontent.com/62789906/185597977-619fc06d-0e9c-414c-8bf9-fd8b8eba72a3.png)

You can update the flat data using the endpoint /api/Flats (UPDATE). A response as below will be returned:

![aktualizacja mieszkania](https://user-images.githubusercontent.com/62789906/185598518-498e70f6-83fd-4419-82df-978fc017ce8b.png)

Here is the result of removing a flat with a given ID:

![usunięcie mieszkania po ID](https://user-images.githubusercontent.com/62789906/185604078-980f6a08-6288-4d03-95e3-387954b9f0a7.png)

To showcase the pagination and record paging mechanism, 10 new announcements have been added. A 4th page has been displayed. There are 2 records on each page.

![paginacja i stronnicowanie](https://user-images.githubusercontent.com/62789906/185610852-cd999531-aead-4116-b577-3f7354d02c84.png)

-------------------------------------------------------------------------

A mechanism for adding attachments to announcements has been implemented. The path of the file stored on disk is stored in the database. 

![dodawanie załączników](https://user-images.githubusercontent.com/62789906/185611249-bdfd142d-c530-480f-90d8-a0221e79a64e.png)

We can both retrieve data on all attachments for a given announcement and also retrieve an attachment with a given ID.

![wyszukiwanie załączników dla mieszkania o danym ID](https://user-images.githubusercontent.com/62789906/185611668-416db235-8b53-453a-ac96-2937329dbc94.png)

![wyszukanie załącznika o danym ID z możliwością pobrania](https://user-images.githubusercontent.com/62789906/185611678-273b6f75-bd9f-44f0-856b-c64893d75ce7.png)

-------------------------------------------------------------------------

On a similar basis, we can add pictures to our announcements. However, these are stored directly in the database as a string and then converted accordingly to be presented in the browser. As with attachments, it is possible to download a particular image or information about all images assigned to an ID announcement.

![dodanie nowego obrazka](https://user-images.githubusercontent.com/62789906/185615880-ece8c8ec-f1a7-49ae-ab84-bdd0736e8437.png)

-------------------------------------------------------------------------
