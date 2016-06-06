#Events und Delegates

##Aufgabe 1

Für Event-basierte Programmierung gibt es in C#/.Net Unterstützung auf Programmiersprachenebene 
und im IL-Code durch die Schlüsselworte event, delegate, sowie durch die Möglichkeit, anonyme 
Methoden zu implementieren. In Java gibt es für die Implementierung Event-basierter Konzepte
die Klasse java.util.EventObject, sowie ein Pattern bzw. eine Konvention, wie 
EventSource-Objekte zu implementieren sind. Für die Implementierung EventListener gibt es 
anonyme Klassen. Stellen Sie die Konzepte in C# und Java gegenüber. Wo sind die Unterschiede,
ggf. Vor- und Nachteile?

##Aufgabe 2

Betrachten Sie die Methode [`ImageData.Blt()`](https://github.com/FUSEEProjectTeam/Fusee/blob/develop/src/Base/Common/ImageData.cs#L199)
aus dem FUSEE-Source-Code, die die klassische [_Bit Block Transfer_](https://de.wikipedia.org/wiki/Bit_blit)
-Operation implementiert, also einen rechteckigen Ausschnitt aus einer Bilddaten-Quelle an 
eine beliebige Position in einem Bilddaten-Ziel kopiert. Wenn Quell- und Ziel-Datenbereich
unterschiedliche Pixel-Formate enthält, muss pro Pixel eine Konvertierung stattfinden. Die 
FUSEE-Lösung verwendet hier Delegates, um die Pro-Pixel (ggf. auch die Pro-Zeile) Operation
beim Kopieren zu implementieren.
 - Warum werden hier Delegates verwendet? Was wären ggf. Alternativen, mit welchen 
   Vor-/Nachteilen?
   
 - Momentan werden nur die drei im [`enum ImagePixelFormat`](https://github.com/FUSEEProjectTeam/Fusee/blob/develop/src/Base/Common/ImageData.cs#L11)
   deklarierten Pixelformate unterstützt. Fügen Sie ein neues Pixel-Format ein, z.B. HSL.
   Siehe auch [_Umrechnung HSL <-> RGB_](https://de.wikipedia.org/wiki/HSV-Farbraum).       


##Aufgabe 3
Kovarianz und Kontravarianz funktioniert auch für generische Interfaces. Finden Sie ein Beispiel für IList<T>
