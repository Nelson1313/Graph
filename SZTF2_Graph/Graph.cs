using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTF2_Graf
{
    class Graph<T>
    {
        public delegate void CrawlerHandler(T content);
        public delegate void GraphEventHandler<T>(object source, GraphEventArgs<T> geargs);
        public event GraphEventHandler<T> EdgeAdded;

        public class GraphEventArgs<T>
        {
            public T A { get; set; }
            public T B { get; set; }
            public GraphEventArgs(T A, T B)
            {
                this.A = A;
                this.B = B;
            }
        }

        List<List<T>> neighborList;
        List<T> content;

        public Graph()
        {
            neighborList = new List<List<T>>();
            content = new List<T>();
        }

        public void AddNode(T node)
        {
            content.Add(node);
            neighborList.Add(new List<T>());
        }

        public void AddEdge(T from, T to)
        {
            GraphEventArgs<T> args = new GraphEventArgs<T>(from, to);

            EdgeAdded?.Invoke(this, new GraphEventArgs<T>(from, to)
            {
                A = from,
                B = to

            });
            
            int indexFrom = content.IndexOf(from);
            int indexTo = content.IndexOf(to);

            neighborList[indexFrom].Add(content[indexTo]);
            neighborList[indexTo].Add(content[indexFrom]);
        }
        public bool HasEdge(T from, T to)
        {
            int indexFrom = content.IndexOf(from);
            int indexTo = content.IndexOf(to);

            return neighborList[indexFrom].Contains(content[indexTo]);
        }

        public List<T> Neighbors(T node)
        {
            int index = content.IndexOf(node);
            return neighborList[index];
        }

        public void BFS(T from, CrawlerHandler _method)
        {
            CrawlerHandler method = _method;
            Queue<T> S = new Queue<T>();
            List<T> F = new List<T>();

            S.Enqueue(from);
            F.Add(from);

            while (S.Count != 0)
            {
                T k = S.Dequeue();
                method?.Invoke(k);
                foreach (T x in Neighbors(k))
                {
                    if (!F.Contains(x))
                    {
                        S.Enqueue(x);
                        F.Add(x);
                    }
                }
            }
        }

        public void DFS(T firstNode, CrawlerHandler _method)
        {
            List<T> F = new List<T>();
            DFS(firstNode, F, _method);
        }

        private void DFS(T k, List<T> F, CrawlerHandler _method)
        {
            CrawlerHandler method = _method;
            F.Add(k);
            method?.Invoke(k);

            foreach (T item in Neighbors(k))
            {
                if(!F.Contains(item))
                {
                    DFS(item, F, _method);
                }
            }
        }
    }
}
