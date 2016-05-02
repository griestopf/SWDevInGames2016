#Visitor Pattern

Basiert auf [Tutorial 04] (https://github.com/griestopf/Fusee.Tutorial/tree/master/Tutorial04) der FUSEE-Tutorials 

Aufgaben:

 - Herausfinden, wie in `RenderAFrame` das Rendern angestossen wird.
 
 - Mit dem Debugger nachvollziehen, wie im `RenderVisitor` die verschidenen `Visit`-Methoden und wie 
   in den einzelnen Nodes die verschidenen `Accept` Methoden aufgerufen werden.
   
 - Einen komplexeren Szenengraph erzeugen.
 
 - Einen `XMLExportVisitor` bauen, der einen Szenengraphen als XML abspeichern kann.
 
 - FRAGE: 
   Alle von `SceneItem` abgeleiteten Klassen haben scheinbar exakt die selbe Implementierung
   von `Accept`:

	```C#
    public override void Accept(Visitor visitor)
	{
		visitor.Visit(this);
	}
	```
    Warum kann man nicht einfach genau diesen Code in die Basisklasse `SceneItem` schreiben und die
	ganzen übereinstimmenden `override`s in den abgeleiteten klassen weglassen?
	
	Antwort: Ausprobieren! Was passiert? Warum?











