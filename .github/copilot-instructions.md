Projektkontext
- Projekt: eShop in /workspaces/eShop (Debian 12 dev container).
- Tech: .NET SDK (C#, ASP.NET Core), Node.js/npm/ESLint, evtl. etwas Frontend-JS/TS.
- Ziel: Saubere, performante, zugängliche Shop-Funktionalitäten (Katalog, Filter, Paging, Landing Page).

Allgemeiner Stil
- Antworte und kommentiere auf Deutsch, kurz und sachlich.
- Bevorzugte Muster: klare, kleine Funktionen; SRP; DI; asynchrone APIs (async/await).
- Schreibe sicheren Code (Null-Checks, Input-Validierung, keine eval/innerHTML mit untrusted Daten).

Datei-/Snippet-Ausgabeformat
- Wenn du Code vorschlägst oder änderst:
  - Verwende Codeblöcke mit vier Backticks.
  - Füge nach den Backticks die Sprache an (z. B. csharp, ts, js, cshtml, html, css, json, sh).
  - Wenn eine bestehende Datei geändert wird, füge als erste Zeile einen Kommentar mit `// filepath: <pfad>` hinzu.
  - Nutze `// ...existing code...` um Kontext zu markieren.
- Beispiel:
  ````csharp
  // filepath: /workspaces/eShop/src/Web/Pages/Index.cshtml.cs
  // ...existing code...
  public async Task OnGetAsync() { /* Änderungen */ }
  // ...existing code...

URLs, Routing, Query-Parameter

Keine absoluten oder localhost-Links. Immer relative URLs.
Nutze konsistente Query-Parameter: page, pageSize, sort, brand, type, search, minPrice, maxPrice.
Filter/Paging müssen URL-Parameter lesen und schreiben, damit Deep-Linking/Refresh funktionieren.
Preisfilter (Slider)

UI: Doppelslider für minPrice/maxPrice mit Live-Labeln, Tastaturbedienung und ARIA (a11y).
Debounce Eingaben (300–500 ms) bevor Requests ausgelöst werden.
Synchronisiere Slider-Werte mit Query-Params (minPrice/maxPrice). Auf Reset: entferne die Params.
Server/Backend muss die Preisspanne validieren (min <= max, Grenzen) und korrekt filtern.
Keine Abhängigkeit von externen CDNs; verwende native Inputs oder kleine lokale Utilities.
Paginierung

Nutze relative Links, übernimm bestehende Filter-Query-Params (brand, type, search, minPrice, maxPrice).
Edge-Cases: Seite > Max → auf letzte Seite clampen; Seite < 1 → 1.
Zeige Disabled-States für Prev/Nächste, a11y-konform.
Frontend (JS/TS)

Minimaler Footprint (kein großes Framework, falls nicht vorhanden).
Module (ESM), kein globales Leaking.
Lint-konform (ESLint); npm run lint soll sauber sein.
Event Listener entkoppeln, Cleanup vorsehen bei SPA-artigen Aktualisierungen.
Backend (.NET)

ASP.NET Core: Endpoints/MVC sauber trennen; DTOs statt Entities in Views.
EF Core: No-Tracking für Leseabfragen, Pagination mit Skip/Take, Server-seitige Filterung.
Validierung: DataAnnotations/FluentValidation.
Logik in Services kapseln; Controller/Pages schlank halten.
Tests & Qualität

Schreib Unit- und Integrationstests für Filter-/Paging-Logik.
Teste URL-Parsing und -Generierung (Query-Param-Roundtrip).
CI-freundlich: dotnet test und npm run lint müssen grün sein.
Performance & Barrierefreiheit

Bevorzuge Server-seitiges Filtern und Pagination.
A11y: Labels, ARIA-Attributes, Fokuszustände, Tastaturbedienung für Slider/Links.
Lazy-Loading von Assets nur falls sinnvoll; keine Layout-Shifts.
Sicherheit

Validiere alle Query-Parameter (Typ/Range).
Vermeide XSS (HTML-Encoding in Views, keine ungesicherten innerHTML-Zuweisungen).
Keine geheimen Daten in Client-Logs oder HTML.
Dev-Container & Tools

Linux-Befehle verwenden. Beispiele:
Build/Tests: dotnet build, dotnet test
Lint: npm ci && npm run lint
Browser öffnen: "$BROWSER" http://localhost:5000
Docker/CLI/Azure CLI sind vorhanden, aber nur nutzen, wenn angefordert.
Kommunikation & Nachfragen

Bei Unklarheiten kurze Rückfragen stellen (z. B. Pfade, Framework-Variante, gewünschtes UI).
Mach kleine, prüfbare Schritte und nenne erforderliche Befehle zum Testen.
Konventions-Reminder

Schreibe relative Imports/Pfade.
Benenne Dateien und Symbole selbsterklärend.
Halte dich an bestehenden Stil des Projekts.