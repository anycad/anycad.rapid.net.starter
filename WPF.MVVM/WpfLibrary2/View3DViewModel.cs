using AnyCAD.Foundation;
using AnyCAD.WPF;
using Prism.Events;
using Prism.Mvvm;

namespace WpfLibrary2
{
    public class View3DViewModel : BindableBase
	{
		private IEventAggregator _ea;
		private RenderControl? _renderControl;
		public List<SceneNode> sceneNodes { get; set; }
		int i = 0;

		public View3DViewModel(IEventAggregator ea)
		{
			_ea = ea;
			sceneNodes = new List<SceneNode>();

			_ea.GetEvent<WpfLibrary2.Events.Draw>().Subscribe(draw);
		}

		public void SetRenderControl(RenderControl renderControl)
		{
			_renderControl = renderControl;
		}

		public void draw(int id)
		{
			foreach (SceneNode node in sceneNodes)
			{
				_renderControl.RemoveSceneNode(node.GetUuid());
				sceneNodes = new List<SceneNode>();
			}


			if (id == 1)
			{
				TrajectoryParameterModel tpm = new TrajectoryParameterModel();
				tpm.startPoint = new Vector3(0, 0, 0);
				tpm.endPoint = new Vector3(100, 100, 100);
				tpm.deviceId = 1;

				addLine(tpm);
			}
			else if (id == 2)
			{
				TrajectoryParameterModel tpm = new TrajectoryParameterModel();
				tpm.startPoint = new Vector3(100, 100, 100);
				tpm.endPoint = new Vector3(500, 100, 100);
				tpm.deviceId = 2;

				addLine(tpm);
			}


			_renderControl.ViewContext.ClearTemp();

			foreach (SceneNode node in sceneNodes)
			{
				_renderControl.ShowSceneNode(node);
			}

			i++;
		}




		public void addLine(TrajectoryParameterModel trajPar)
		{
			GroupSceneNode groupSceneNode = new GroupSceneNode();
			groupSceneNode.SetChildrenPickable(false);  

			SceneNode nodePoint = addPoint(trajPar.endPoint, new Vector3(0, 0, 0), 8f);
			groupSceneNode.AddNode(nodePoint);

			var topoShape = SketchBuilder.MakeLine(new GPnt(trajPar.startPoint.x, trajPar.startPoint.y, trajPar.startPoint.z),
				new GPnt(trajPar.endPoint.x, trajPar.endPoint.y, trajPar.endPoint.z));

			var material = LineDashedMaterial.Create("");//my.dashed.material
			material.SetColor(new Vector3(255, 0, 0));
			material.SetDashSize(2);
			material.SetLineWidth(2);
			material.SetName("1");

			var node = BrepSceneNode.Create(topoShape, null, material);
			node.SetSubShapePickable(false);

			node.SetUserId(1);
			groupSceneNode.AddNode(node);
			groupSceneNode.SetUserId(1);
			sceneNodes.Add(groupSceneNode);
		}


		public SceneNode addAxis(Vector3 pos, Vector3 dir, float length)
		{
			var widget = AxisWidget.Create(0.5f, new Vector3(length));
			var trf = Matrix4.makeTranslation(pos);
			trf = trf * Matrix4.makeRotationAxis(new Vector3(1, 0, 0), (float)(dir.x / 180 * Math.PI));
			trf = trf * Matrix4.makeRotationAxis(new Vector3(0, 1, 0), (float)(dir.y / 180 * Math.PI));
			trf = trf * Matrix4.makeRotationAxis(new Vector3(0, 0, 1), (float)(dir.z / 180 * Math.PI));

			SceneNode? instance = widget.Clone();
			instance.SetTransform(trf);

			return instance;
		}


		public SceneNode addPoint(Vector3 point, Vector3 pointColor, float pointSize)
		{
			var material = PointsMaterial.Create("points-material"); //points-material
			material.SetPointSize(pointSize); //5.0f
			material.SetPointStyle(EnumPointStyle.Dot);
			material.SetColor(pointColor);
			material.SetTransparent(true);
			material.SetSizeAttenuation(false);
			PrimitiveSceneNode node = new PrimitiveSceneNode(GeometryBuilder.AtomPoint(), material);
			node.SetTransform(Matrix4.makeTranslation(point));

			return node;
		}


		public class TrajectoryParameterModel
		{
			public int deviceId { get; set; }

			public Vector3? startPoint { get; set; }
		
			public Vector3? endPoint { get; set; }
			
		}






	}
}
