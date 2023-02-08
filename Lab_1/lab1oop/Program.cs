public class TCircle : ICloneable
{
    public int r;
    public TCircle()
    {

    }
    public TCircle(int r)
    {
        this.r = r;
    }
    public object Clone()
    {
        return new TCircle(r);
    }
    public void setprintCircle()
    {
        System.Console.WriteLine("Введiть радiус:");
        this.r = Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine("Радiус:");
        System.Console.WriteLine(r);
    }
    public new double AreaCircle()
    {
        return Math.Pow(r * 3.14, 2);
    }
    public void AreaofSector()
    {
        System.Console.WriteLine("Введiть кут сектора:");
        int x = Convert.ToInt32(Console.ReadLine());
        double y = (Math.Pow(r * 3.14, 2) * x) / 360;
        System.Console.WriteLine("Площа сектора: " + y);
    }
    public void Length()
    {
        double c = r * 3.14 * 2;
        System.Console.WriteLine("Довжина кола: " + c);
    }
    public void Compare(TCircle r1, TCircle r2)
    {
        if (r1.r > r2.r)
        {
            System.Console.WriteLine("Коло 1 бiльше");
        }
        else
        if(r1.r < r2.r)
        {
            System.Console.WriteLine("Коло 1 менше");
        }
        else
        {
            System.Console.WriteLine("Кола однаковi");
        }
    }
    public static TCircle operator +(TCircle r1, TCircle r2)
    {
        return new TCircle(r1.r + r2.r);
    }
    public static TCircle operator -(TCircle r1, TCircle r2)
    {
        return new TCircle(r1.r - r2.r);
    }
    public static TCircle operator *(TCircle r1, int x)
    {
        return new TCircle(r1.r * x);
    }

}
public class TSphere : TCircle
{
    public int r;
    public TSphere()
    {

    }
    public TSphere(int r)
    {
        this.r = r;
    }
    public object Clone()
    {
        return new TSphere(r);
    }
    public void setprintSphere()
    {
        base.setprintCircle();
    }
    public new double AreaSphere()
    {
        return 4*base.AreaCircle();
    }
}
class MainCode
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Коло 1: ");
        TCircle c1 = new TCircle();
        c1.setprintCircle();
        System.Console.WriteLine("Площа круга: " + c1.AreaCircle());
        c1.AreaofSector();
        c1.Length();
        System.Console.WriteLine("Коло 2: ");
        TCircle c2 = new TCircle();
        c2.setprintCircle();
        c1.Compare(c1, c2);
        TCircle c3 = c1+c2;
        System.Console.WriteLine("Сума радiусiв: "+ c3.r);
        TCircle c4 = c1 - c2;
        System.Console.WriteLine("Рiзниця радiусiв: " + c4.r);
        System.Console.WriteLine("Введiть число для множення:");
        int x = Convert.ToInt32(Console.ReadLine());
        TCircle c5 = c1 * x;
        System.Console.WriteLine("Добуток: " + c5.r);
        System.Console.WriteLine("");
        System.Console.WriteLine("Сфера: ");
        TSphere s1 = new TSphere();
        s1.setprintSphere();
        System.Console.WriteLine("Площа поверхнi сфери: " + s1.AreaSphere());
    }
}
