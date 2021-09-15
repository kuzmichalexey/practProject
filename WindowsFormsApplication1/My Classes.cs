using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Graph
   {
private int[,] mas=new int[3,25];
public void AddVer(int rebra,int a1, int a2, int a3)
	{
		mas[0,rebra] = a1;
		mas[1,rebra] = a2;
		mas[2,rebra] = a3;
	}
	public int GiveRebrIz(int n )
	{
		    int a1=mas[0,n];		
			return a1;
	}
	public int GiveRebrTo(int n)
	{
		int a2 = mas[1,n];
		return a2;
	}
	public int GiveRebrVes(int n)
	{
		int a3 = mas[2,n];
		return a3;
	}
	public void sort(int size)
	{
		for (int i = 0; i < size; i++)
		for (int j = i + 1; j < size; j++)
		{
			if (mas[2,i] > mas[2,j])
			{
				int temp;
				temp = mas[2,i];
				mas[2,i] = mas[2,j];
				mas[2,j] = temp;
				
				temp = mas[1,i];
				mas[1,i] = mas[1,j];
				mas[1,j] = temp;
				
				temp = mas[0,i];
				mas[0,i] = mas[0,j];
				mas[0,j] = temp;
			}
		}
	}
};
    }

