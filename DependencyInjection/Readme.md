#Dependency Injected Calculator  

Die folgende Aufgabe verwendet eine leichte Abwandlung des [Calculator-Beispiel aus dem Managed Extensibility
Framework](http://msdn.microsoft.com/de-de/library/dd460648.aspx).

1. Öffnen Sie Calculator0.sln. Hierbei handelt es sich um einen 
   Kommandozeilen-Rechner, der jeweils zwei Operanden mit einer Operation verknüpft. Derzeit sind
   die vier Grundrechenarten als Operationen implementiert. Bauen Sie das Projekt und verwenden Sie es.
   Fügen Sie weitere (binäre) Operationen hinzu, z.B. Fakultät, Potenzieren, n-te Wurzel.
        
2. Nun soll es möglich sein, den Rechner auch „von außen“ mit neuen Operationen auszustatten.
   So gesehen ist der Rechner die Hauptapplikation und neue Operationen sollen über DLLs als Plug-Ins
   hinzugefügt werden können. Implementieren Sie diese Funktionalität mit Hilfe des 
   Managed Extensibility Framework.

##Aufgabe 1
 
Fügen Sie der im Unterricht erarbeiteten Lösung zum Calculator-Beispiel ein neues DLL-Projekt hinzu, 
in dem weitere Operatoren implementiert sind. Zur Laufzeit sollen diese Operatoren auch dem Calculator 
zur Verfügung stehen. Erweitern Sie daher Ihren Catalog um einen `DirectoryCatalog`:

```C# 
  catalog.Catalogs.Add(new DirectoryCatalog(<Direcotry-Pfad zu DLLs>));
```

##Aufgabe 2

Vergleichen Sie die im Unterricht erarbeitete Lösung zum Calculator-Beispiel mit der im oben angegebenen 
Link zum Original. Wo sind die Unterschiede? Die im Microsoft-Beispiel verwendete Lösung benutzt das im MEF (Managed
Extensibility Framework) definierte Generic `Lazy<T, TMetadata>`. Dieses ist von der allgemeineren Klasse 
`Lazy<T>` abgeleitet. Welchen Nutzen hat die Klasse `Lazy<T>`? Warum ist dieser Nutzen für die Verwendung im
MEF von Vorteil? 

##Aufgabe 3

An welchen Stellen könnte die Verwendung eines DI-Container wie MEF in einer Game-Engine (z.B. FUSEE, Unity 3D) oder einem
Game sinnvoll sein?

##Aufgabe 4

Lesen Sie den Artikel von Martin Fowler, dem „Erfinder von Dependency Injection“:
http://martinfowler.com/articles/injection.html.

Lesen Sie die einleitenden Artikel über das Unity-Dependency-Injection-Framework
http://msdn.microsoft.com/en-us/library/dn170416.aspx.


