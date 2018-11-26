<?php

use App\DetallePedido;
use Illuminate\Database\Seeder;

class DetallePedidoSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
      DB::statement('SET FOREIGN_KEY_CHECKS=0;');
      DB::table('detalle_pedidos')->truncate();
      DB::statement('SET FOREIGN_KEY_CHECKS=1;');

      DetallePedido::create([
            'pedido_id'=> '001',
            'producto_id' => '001',
            'cantidad' => '5'
        ]);
      DetallePedido::create([
            'pedido_id'=> '001',
            'producto_id' => '002',
            'cantidad' => '8'
        ]);
      DetallePedido::create([
            'pedido_id'=> '002',
            'producto_id' => '001',
            'cantidad' => '2'
        ]);
      DetallePedido::create([
            'pedido_id'=> '002',
            'producto_id' => '002',
            'cantidad' => '8'
        ]);
    }
}
