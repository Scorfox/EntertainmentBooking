namespace Booking.Donmain
{
    //public class datacontext : dbcontext
    //{
    //    // public dbset<классописывающийзаписьвтаблице> названиебудущейтаблицы { get; set; }
    //    public dbset<tableentity> Tables { get; set; }
    //    public dbset<reservationentity> Reservations { get; set; }

    //    public datacontext()
    //    {
    //        database.ensurecreated();
    //    }

    //    //создание связей между таблицами
    //    protected override void onmodelcreating(modelbuilder modelbuilder)
    //    {
    //        modelbuilder.entity<Table>()
    //            .hasmany(t => t.reservations)   // у стола много заказов
    //            .withone(r => r.tableid)        // у каждого заказа есть один стол
    //            .hasforeignkey(r => r.id);      // внешний ключ в таблице заказов
    //    }

    //    protected override void onconfiguring(dbcontextoptionsbuilder optionsbuilder)
    //    {
    //        optionsbuilder.usenpgsql("host=localhost;port=54432;username=postgres;password=password;database=otus.hw_db1");

    //        base.onconfiguring(optionsbuilder);
    //    }
    //}
}
