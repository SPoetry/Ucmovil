<?php

use App\Inventario;
use Illuminate\Database\Seeder;

class InventarioSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
      DB::statement('SET FOREIGN_KEY_CHECKS=0;');
      DB::table('inventarios')->truncate();
      DB::statement('SET FOREIGN_KEY_CHECKS=1;');

      Inventario::create([
            'id_producto'=> '001',
            'nombre' => 'Silla con 4 patas',
            'imagen' => 'http://admin.officinca.com/SVsitefiles/officinc/producto/med/f47c65_SILLA_ATENAS_VISIT_1.jpg',
            'cantidad' => '20'
        ]);

      Inventario::create([
            'id_producto'=> '002',
            'nombre' => 'Escritorio',
            'imagen' => 'https://d26lpennugtm8s.cloudfront.net/stores/337/959/products/escritorio-print-negro-satinado1-96c580c939005043ab15123788476536-640-0.jpg',
            'cantidad' => '2'
        ]);

      Inventario::create([
            'id_producto'=> '003',
            'nombre' => 'Lapiz pasta bic',
            'imagen' => 'https://estacionmurcia.cl/store/478/lapiz-pasta-bic.jpg',
            'cantidad' => '20'
        ]);

      Inventario::create([
            'id_producto'=> '004',
            'nombre' => 'Chalas Zico',
            'imagen' => 'http://s3-sa-east-1.amazonaws.com/lalegal/app/public/system/photos/1994/original/zico.jpg?1419303348',
            'cantidad' => '1'
        ]);

      factory(Inventario::class, 10)->create();
    }
}
