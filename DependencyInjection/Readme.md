##Aufgabe 1 

Die folgende Aufgabe verwendet das Calculator-Beispiel des Managed Extensibility Framework:
http://msdn.microsoft.com/de-de/library/dd460648(v=vs.110).aspx

1. Laden Sie das Projekt „Step0-NoDepInj“ von der Kursseite. Hierbei handelt es sich um einen 
   Kommandozeilen-Rechner, der jeweils zwei Operanden mit einer Operation verknüpft. Derzeit sind
   die vier Grundrechenarten als Operationen implementiert. Bauen Sie das Projekt und verwenden Sie es.
   Fügen Sie weitere (binäre) Operationen hinzu, z.B. Fakultät, Potenzieren, n-te Wurzel.
        
2. Nun soll es möglich sein, den Rechner auch „von außen“ mit neuen Operationen auszustatten.
   So gesehen ist der Rechner die Hauptapplikation und neue Operationen sollen über DLLs als Plug-Ins
   hinzugefügt werden können. Implementieren Sie diese Funktionalität mit Hilfe des 
   Managed Extensibility Framework.

##Aufgabe 2
 
Fügen Sie der im Unterricht erarbeiteten Lösung zum „Calculator-Beispiel“ ein neues DLL-Projekt hinzu, in dem weitere Operatoren implementiert sind. Zur Laufzeit sollen diese Operatoren auch dem Calculator zur Verfügung stehen. Erweitern Sie daher Ihren Catalog um einen „DirectoryCatalog“: 
catalog.Catalogs.Add(new DirectoryCatalog(<Direcotry-Pfad zu DLLs>));

##Aufgabe 3

Vergleichen Sie die im Unterricht erarbeitete Lösung zum „Calculator-Beispiel“ mit der in Aufgabe 6 angegebenen Link. Wo sind die Unterschiede?
Die im Microsoft-Beispiel verwendete Lösung benutzt das im MEF (Managed Extensibility Framework) definierte Generic Lazy<T, TMetadata>. Dieses ist von der allgemeineren Klasse Lazy<T> abgeleitet. Welchen Nutzen hat die Klasse Lazy<T>? Warum ist dieser Nutzen für die Verwendung im MEF von Vorteil? 

##Aufgabe 4
Betrachten Sie die Klasse ImpFactory im Fusee.Core Projekt. Wie könnte hier Dependency Injection verwendet werden? 
Betrachten Sie das FUSEE-Example AppBrowserWinForms. Wie könnte hier Dependency Injection verwendet werden?
Versuchen Sie Lösungen mit dem MEF Dependency Injection Container zu skizzieren.
