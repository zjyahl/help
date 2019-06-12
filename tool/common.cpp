n(n+1)/2
bool addExact(int a, int b)
{
	int c = a + b;
	if(((c ^ a) & (c ^ b)) < 0)
	{
		return false;
	}
	return true;
}
bool substractExact(int a, int b)
{
	int c = a - b;
	if(((a ^ c) & (a ^ b)) < 0)
	{
		return false;
	}
	return true;
}
bool multiplyExact(int a, int b)
{
	int c = a * b;
	int _a = Match.abs(a);
	int _b = Match.abs(b);
	if(((_a | _b) >>> 15 !=0))
	{
		if(((b != 0) && (c / b !=a)) || (x == Int.MIN_VALUE && b = -1))
		{
			return false;
		}
	}
	return true;
}
bool powOfTwo(int a)
{
	return a & -a == a;
}
int loopInx(int inx, int len)
{
	if(powOfTwo(len))
	{
		return inx & (len - 1);
	}
	return inx % len;
}