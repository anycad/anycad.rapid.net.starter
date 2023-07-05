// See https://aka.ms/new-console-template for more information

using AnyCAD.Foundation;

GlobalInstance.Initialize();

var window3d = RenderingEngine.CreateWindow3D("AnyCAD", 1024, 768, true);

var box = ShapeBuilder.MakeBox(GP.XOY(), 10, 20, 30);
var node = BrepSceneNode.Create(box, null, null, 0.01);
var scene = window3d.GetContext().GetScene();
scene.AddNode(node);

window3d.Run(null);

window3d.Destroy();

GlobalInstance.Destroy();
