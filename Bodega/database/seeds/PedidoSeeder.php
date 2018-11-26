<?php

use Illuminate\Database\Seeder;
use App\Pedido;

class PedidoSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
      DB::statement('SET FOREIGN_KEY_CHECKS=0;');
      DB::table('pedidos')->truncate();
      DB::statement('SET FOREIGN_KEY_CHECKS=1;');

      Pedido::create([
              'user_id' => '003',
              'estado' => '0',
              'tipo' => '0'
      ]);

      Pedido::create([
              'user_id' => '002',
              'estado' => '0',
              'tipo' => '1'
      ]);
    }
}
