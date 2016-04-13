#MeshBuilder Assignment

In dieser Aufgabe wird die folgendermaßen deklarierte Hilfs-Struktur „Vertex“ verwendet:

```C#
struct Vertex
{
    public float3 Position;
    public float3 Normal;
}
```

In einer auf einem dem [Fusee-Tutorial 03] (https://github.com/griestopf/Fusee.Tutorial/tree/master/Tutorial03) basierenden Beispiel erzeugen Sie die Klasse „Geometry“, die folgende Methoden enthält:

```C#
public class MeshBuilder
{
    void AddConvexPoly(Vertex[] vertices);
    void AddTri(Vertex a, Vertex b, Vertex c);
    void AddQuad(Vertex a, Vertex b, Vertex c, Vertex d);
    Mesh CreateMesh();
}
```

Mit den Add… Methoden sollen (konvexe) Polygone eingefügt werden. Dabei sollen Polygone mit mehr als drei Eckpunkten automatisch in Dreiecke umgewandelt werden – 
das geht straightforward, weil vorausgesetzt wird, dass die Polygone konvex sind.
Mit CreateMesh soll ein FUSEE-Mesh zurückgegeben werden, in dem sämtliche Polygone enthalten sind. Dabei sollen Eckpunkte, die in Position UND Normale übereinstimmen, 
auch nur einmal im resultierenden Mesh auftauchen und mehrfach indiziert werden.
Überlegen Sie sich, ob es besser ist, das Herausfiltern von übereinstimmenden Eckpunkten schon beim Hinzufügen von Polygonen oder erst beim Erzeugen des Mesh zu implementieren.
Erzeugen Sie eine Lösung, die prinzipiell mit beliebig vielen Polygonen und Eckpunkten (im ersten Schritt mit weniger als 65000) umgehen kann. Verwenden Sie 
Standard-C#-Containerklassen oder selbst implementierte Containerklassen, die auf Generics basieren. Welche Containerklasse ist geeignet, um die Frage „Ist der 
Eckpunkt [(x, y, z), (xn, yn, zn)] schon enthalten?“ beantworten zu können.

Implementieren Sie mit Hilfe von MeshBuilder Routinen, die Quader, Kugel, Zylinder, Kegel, Röhre, Torus, etc. erzeugen können und dabei ein sinnvolle Parametrisierung (wie z.B. polygonale Aufteilung, Segmentierung u.ä. erlauben – siehe CINEMA 4D). 
