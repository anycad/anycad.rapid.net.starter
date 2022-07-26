using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStarter
{
    public class TreeModel<T1> : INotifyPropertyChanged
    {
        public TreeModel()
        {
            this.IsSelected = false;
            _children = new ObservableCollection<TreeModel<T1>>();
        }

        private TreeModel<T1> _parent;
        protected ObservableCollection<TreeModel<T1>> _children;
        private T1 _Value;
        private string _displayText;
        private bool _isSelected;
        private bool _isExpanded;

        public TreeModel<T1> Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                NotifyPropertyChanged(nameof(Parent));
            }
        }

        public IEnumerable<TreeModel<T1>> Children
        {
            get { return _children; }
        }

        public T1 Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                NotifyPropertyChanged(nameof(Value));
            }
        }

        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                _displayText = value;
                NotifyPropertyChanged(nameof(DisplayText));
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyPropertyChanged(nameof(IsSelected));
            }
        }

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                _isExpanded = value;
                NotifyPropertyChanged(nameof(IsExpanded));
            }
        }



        public void AddChild(TreeModel<T1> child)
        {
            child.Parent = this;
            this._children.Add(child);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public static TreeModel<T1> GetNodeById(T1 id, IEnumerable<TreeModel<T1>> nodes)
        {
            foreach (var node in nodes)
            {
                if (node.Value.Equals(id))
                    return node;

                var foundChild = GetNodeById(id, node.Children);
                if (foundChild != null)
                    return foundChild;
            }
            return null;
        }

        public static TreeModel<T1> GetSelectedNode(IEnumerable<TreeModel<T1>> nodes)
        {
            foreach (var node in nodes)
            {
                if (node.IsSelected)
                    return node;

                var selectedChild = GetSelectedNode(node.Children);
                if (selectedChild != null)
                    return selectedChild;
            }

            return null;
        }

        public static void ExpandParentNodes(TreeModel<T1> node)
        {
            if (node.Parent != null)
            {
                node.Parent.IsExpanded = true;
                ExpandParentNodes(node.Parent);
            }
        }

        public static void ToggleExpanded(IEnumerable<TreeModel<T1>> nodes, bool isExpanded)
        {
            foreach (var node in nodes)
            {
                node.IsExpanded = isExpanded;
                ToggleExpanded(node.Children, isExpanded);
            }
        }
    }

    public class TreeModel : TreeModel<Guid>
    {
        public static ObservableCollection<TreeModel> GetData()
        {
            var data = new ObservableCollection<TreeModel>();

            for (int i = 1; i <= 3; i++)
            {
                var node = new TreeModel() { DisplayText = string.Format("Item {0}", i), Value = Guid.NewGuid() };

                for (int j = 1; j <= 3; j++)
                {
                    var child = new TreeModel() { DisplayText = string.Format("Item {0}.{1}", i, j), Value = Guid.NewGuid() };
                    node.AddChild(child);

                    for (int k = 1; k <= 3; k++)
                    {
                        child.AddChild(new TreeModel() { DisplayText = string.Format("Item {0}.{1}.{2}", i, j, k), Value = Guid.NewGuid() });
                    }
                }

                data.Add(node);
            }

            return data;
        }
    }
}
