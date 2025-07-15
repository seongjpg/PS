public class Node<T> where T : IComparable<T> { // T : data type / where T : IComparable<T> : 비교 가능함을 보장
	public T Val { get; set; }
	public Node<T> Left { get; set; }
	public Node<T> Right { get; set; }
	public Node(T val)
	{
		Val = val;
	}

	public void Insert(T newVal)
	{
		int cmp = newVal.CompareTo(Val);
		if (cmp < 0)
		{
			if (Left == null) Left = new Node<T>(newVal);
			else Left.Insert(newVal);
		}
		else
		{
			if (Right == null) Right = new Node<T>(newVal);
			else Right.Insert(newVal);
		}
	}

	public bool Contains(T target)
	{
		int cmp = target.CompareTo(Val);
		if (cmp == 0) return true;
		if (cmp < 0) return Left.Contains(target) ? true : false;
		return Right.Contains(target) ? true : false;
	}
}

/*
 좌측에는 부모보다 작은 값을, 우측에는 부모보다 큰 값을 배치하는 bst
 */