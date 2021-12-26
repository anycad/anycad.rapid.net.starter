// See https://aka.ms/new-console-template for more information

using AnyCAD.Foundation;

GlobalInstance.Initialize();

WindowCanvas canvas = new WindowCanvas("AnyCAD", true);
canvas.Initialize(0, 600, 400);

var box = ShapeBuilder.MakeBox(GP.XOY(), 10, 20, 30);
var node = BrepSceneNode.Create(box, null, null, 0.01);
var scene = canvas.GetContext().GetScene();
scene.AddNode(node);
canvas.Run();

canvas.Destroy();

GlobalInstance.Destroy();
