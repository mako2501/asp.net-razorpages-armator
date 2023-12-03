"# asp.net-razorpages-armator" 
Aplikacja ASP.NET Core 7.0 w Razor Pages
Rafał MAKOWSKI gd14798
Aplikacja pozwala na tworzenie statków morskich (kilku ich parametrów) oraz portów morskich (miejscowości)
Ww. obiekty można podglądać (szczegóły), edytować i usuwać
Statki mogą być umieszczane w portach, w każdym porcie może być wiele statków (szczegóły portu)

Najciekawsze rzeczy:
- Ship Index sortowany po nazwach statków
	- filtrowanie po banderach wybieranych z listy (listwa tworzona dynamicznie w zaleznosci od bander)
	- filtrowanie po nazwie podawanej z input text
	- w tabeli znajduje się nazwa portu do którego zawinął statek
- Ship Details - +informacja w którym porcie znajduje się statek - 
- Ship Create/Edit:
	- typ statku wybór z Select - dane z klasy ShipTypes dziedziczącej po SelectListItem
	- można dodać port w którym znajduje się statek za pomocą Select, wypełnienie danymi przez funkcję klasy PortsNamePageModel dziedziczy z PageModel
- pierwsze uruchomienie aplikacji inicjuje SeedData, który to wypałnia bazę pierwszymi predefiniowanymi wartościami
- zastosowanie relacji 1 do wielu, statek moze być w jednym porcie, w porcie może być wiele statków - statki dodaje się do portu ze strony Ship Details
- przed usunięciem portu ustawiam statkom, które są w tym porcie wartość NULL
