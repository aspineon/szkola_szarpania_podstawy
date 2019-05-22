using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyManager.Items;

namespace MoneyManager.Db.Files
{
    class File : IReader, IWriter
    {
        private IList<Item> _list;

        public File()
        {
            _list = new List<Item>();
        }

        public void Write(Item item)
        {
            _list.Add(item);
        }

        public void Remove(int id)
        {
            Item toRemove = null;

            foreach(Item item in _list)
            {
                if (item.Id == id)
                {
                    toRemove = item;
                    break;
                }
            }

            _list.Remove(toRemove);
        }

        public IEnumerable<Item> ReadAll()
        {
            return _list;
        }

        public int GetNextId()
        {
            if (_list.Count == 0)
            {
                return 1;
            }

            int lastIndex = _list.Count - 1;

            return _list[lastIndex].Id + 1;
        }
    }
}
