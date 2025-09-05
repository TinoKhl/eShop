---
applyTo:
  - "src/**/wwwroot/**/*.js"
  - "src/**/wwwroot/**/*.mjs"
---

# JavaScript (ESM, wwwroot)
- ESM-Module, keine Globals; exportierte Initialisierer verwenden.
- Query-Params nur mit URLSearchParams ändern; ausschließlich relative URLs (kein Host/localhost).
- Preisfilter:
  - Doppelslider minPrice/maxPrice mit 300–500 ms Debounce.
  - Werte mit URL syncen; Standardwerte → Params entfernen.
  - Navigation mit `${location.pathname}?${params}` (kein Full-Reload via absolute URL).
- A11y: Live-Labels via textContent, aria-live="polite".
- Sicherheit: kein innerHTML mit untrusted Daten; Null-Checks.
- Cleanup-Funktion bereitstellen (removeEventListener), wenn Listener gesetzt werden.