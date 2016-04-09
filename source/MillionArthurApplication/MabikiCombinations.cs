using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance;

namespace MillionArthurApplication
{
    class MabikiCombinations<T>
    {
        #region メンバ
        private IList<T> _items;
        private int _length;
        private List<IList<T>> _combinations;
        private int[] _finalIndices;
        private int[] _mabiki;
        private int _mabikiCount;
        #endregion

        #region コンストラクタ
        public MabikiCombinations(IList<T> items, int select, int[] mabiki)
        {
            if (select < 0) 
                throw new ArgumentException("選択要素数は、0以上でなくてはなりません。");
            if (items.Count < select)
                throw new ArgumentException("選択要素数は、対象要素数以下でなくてはなりません。");

            _items = items;
            _length = select;
            _combinations = new List<IList<T>>();
            _mabiki = mabiki;
            _mabikiCount = mabiki.Count();

            if (select == 0) return;

            _finalIndices = GetFinalIndices(select);
            ComputeCombination();
        }
        #endregion

        /// <summary>
        /// 選択要素数に応じた組み合わせとなる最後の値を取得します。(終端の確定)
        /// </summary>
        /// <param name="select"></param>
        /// <returns></returns>
        private int[] GetFinalIndices(int select)
        {
            var finalindices = new int[select];

            int j = select - 1;
            for (var i = _items.Count - 1; i > _items.Count - 1 - select; i--)
            {
                finalindices[j] = i;
                j--;
            }
            return finalindices;
        }

        #region プロパティ
        /// <summary>
        /// 組み合わせの要素数を取得します。
        /// </summary>
        public int Count
        {
            get { return _combinations.Count != 0 ? _combinations.Count : 1; }
        }
        #endregion

        /// <summary>
        /// 条件をもとに組み合わせを求めます。
        /// </summary>
        private void ComputeCombination()
        {
            if (_finalIndices.Length == 0) return;

            var indices = Enumerable.Range(0, _length).ToArray();
            _combinations.Add(GetCurrentCombination(indices));

            while (NextCombination(indices))
            {
                if(Check(indices))
                    _combinations.Add(GetCurrentCombination(indices));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indices"></param>
        /// <returns></returns>
        private bool Check(int[] indices)
        {
            bool result = false;
            for (int i = 0; i < _mabikiCount; i++)
            {
                for (int j = 0; j < _length; j++)
                {
                    if (_mabiki[i] == indices[j])
                        return true;
                }
            }
            return result;
        }

        /// <summary>
        /// 現在の組み合わせを取得します。
        /// </summary>
        /// <param name="indices"></param>
        /// <returns></returns>
        private T[] GetCurrentCombination(int[] indices)
        {
            T[] oneCom = new T[_length];
            for (var k = 0; k < _length; k++)
            {
                oneCom[k] = _items[indices[k]];
            }
            return oneCom;
        }

        /// <summary>
        /// 次の組み合わせへ
        /// </summary>
        /// <param name="indices"></param>
        /// <returns></returns>
        private bool NextCombination(int[] indices)
        {
            for (var j = _finalIndices.Length - 1; j > -1; j--)
            {
                if (indices[j] < _finalIndices[j])
                {
                    indices[j]++;
                    for (var k = 1; j + k < _finalIndices.Length; k++)
                    {
                        indices[j + k] = indices[j] + k;
                    }
                    break;
                }
                if (j == 0) return false;
            }
            return true;
        }

        /// <summary>
        /// イテレータ
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IList<T>> GetEnumerator()
        {
            foreach (var item in _combinations) yield return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IList<T>> GetCombinations()
        {
            return _combinations;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}C{1} Of [{2}] - {3}通り"
                　　　　, _items.Count
                        , _length
                        , Utility.GetString<T>(_items)
                        , this.Count);
        }
	}
	public static class Utility
	{
		/// <summary>
		/// IList(T)の要素を文字列化したものすべてを連結した文字列を取得します。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
		public static string GetString<T>( IList<T> list )
		{
			var sb = new StringBuilder();
			foreach ( T item in list )
			{
				sb.Append( item.ToString() + "," );
			}
			if ( sb.Length > 0 ) sb.Remove( sb.Length - 1, 1 );
			return sb.ToString();
		}
	}
}
