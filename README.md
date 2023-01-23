# BankWebApp

1. W pliku appsettings.json należy zmienić: "DefaultConnection": "Data source = (ścieżka do pliku BankDB.db)"
2. W pliku Data/ApplicationDbContext.cs w metodzie OnConfiguring również należy zmienić: optionsBuilder
    .UseSqlite("Data source = (ścieżka do pliku BankDB.cs)");

3. Aplikację należy uruchomić za pomocą Visual Studio 2022
4. Można stworzyć nowego użytkownika za pomocą Register w prawym górnym rogu lub zalogować się na istniejącego:
    Pracownik: admin@mail.com, hasło: admin;
    Klient A: clienta@mail.com, hasło: clientA
    Klient B: clientb@mail.com, hasło: clientB
5. po zalogowaniu wyświtlą się 3 konta walutowe
6. Funkcjami "Add money" oraz "Withdrawal" można testowo dodawać lub wypłacić fundusze
7. Przyciski "History" oraz "Transfer" nie są w pełni gotowe więc nie można z nich jeszcze korzystać
8. Strony "Currency exchange" oraz "Loan application" są przygotowane wizualnie, ale nie posiadają jeszcze żadnej funkcjonalności
9. Strona "Profile" została wygenerowana automatycznie z użyciem IdentityAPI
