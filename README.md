Detta projekt är en svensk konsolapplikation för att hantera ett garage. Programmet gör det möjligt att skapa ett garage, lägga in olika typer av fordon, söka i garaget och spara/ladda garagets tillstånd från JSON-fil.

Projektet är byggt i .NET 10 och fokuserar på enkel användning i terminalen med menyalternativ och datalagring i användarens lokala appdata-katalog.

## Så här startar du programmet

1. Installera .NET 10 SDK.
2. Öppna terminalen i projektets rotmapp.
3. Kör:

```powershell
dotnet run --project GarageDemo2/GarageDemo2.csproj
```

Om programmet sparar state, lagras filen normalt i:

```powershell
%LOCALAPPDATA%\Garage1App\garage-state.json
```

## Klasser och ansvar

### `Program`
Huvudstartpunkten för applikationen. Här byggs dependency injection och appen startas genom `AppManager`.

### `AppManager`
Ansvarar för användarflödet i konsolen. Här finns huvudmenyn, val av operationer, inmatning av data och anrop till garage-tjänsten.

### `GarageService` och `IGarageService`
Tjänstlager som hanterar garagets affärslogik. Den ansvarar bland annat för:
- att skapa och sätta ett garage
- att lista fordon
- att räkna fordon per typ
- att parkera och ta ut fordon
- att söka efter registreringsnummer
- att köra sökningar på egenskaper som färg, typ och antal hjul

### `Garage`
Representerar själva garaget. Här finns logiken för:
- kapacitet
- antal parkerade fordon
- att lägga till fordon
- att ta bort fordon
- att hitta ett fordon via registreringsnummer
- att kontrollera om garaget är fullt eller om registreringsnumret redan finns

### `Vehicle`
Abstrakt basklass för alla fordon. Här finns gemensamma egenskaper som:
- registreringsnummer
- färg
- antal hjul
- validering av registreringsnummer
- textrepresentation via `ToString()`

### Konkreta fordonstyper
- `Car` - bil med bränsletyp
- `Bus` - buss med antal sittplatser
- `Motorcycle` - motorcykel med cylindervolym
- `Airplane` - flygplan med antal motorer
- `Boat` - båt med längd

Varje konkret fordonstyp ärver från `Vehicle` och lägger till sin egen typ-specifika information.

### `Validator`
Kontrollerar att registreringsnummer följer formatet `ABC123` (tre bokstäver och tre siffror). Jämförelser görs utan att ta hänsyn till små/bokstäver.

### `IRepository` och `FileRepository`
Ansvarar för att spara och läsa garagets tillstånd. Programmet använder JSON för att lagra data mellan körningar.

## Kända begränsningar / feedback att få

- Programmet är en konsolapplikation, inte en grafisk app.
- Registreringsnummer-validering är strikt: endast formatet `AAA111` accepteras. Det finns ingen stöd för andra format eller specialfall.
- Garaget hanterar bara ett garage i taget och lagrar state i en enda JSON-fil.
- Sökning är enkel och baseras på ett fåtal fält (typ, färg, antal hjul), inte på full text eller avancerad filtrering.
- Det finns ingen användarhantering eller flera lagringslager.
- Det finns inga automatiska tester i projektet ännu, så det finns utrymme för att förbättra kvalitetssäkring och robusthet.
- Det finns fortfarande vissa namn och strukturer i koden som ser äldre ut (till exempel referenser till `Garage1App` i filnamn och path), vilket skulle kunna göras tydligare och mer konsekvent.

## Mål med projektet

Projektet är ett lärandeprojekt i objektorienterad programmering där man får arbeta med:
- arv och polymorfism
- validering av data
- lagringslösningar
- service-lager och separation av ansvar
- användarinteraktion via terminal

Jag skulle gärna få feedback på:
- hur väl klassansvaret är uppdelat
- om koden är lätt att förstå och underhålla
- om valideringen och lagringen fungerar enligt god design
- om det finns förbättringsområden i struktur, namn eller användarflöde
