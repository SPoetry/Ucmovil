<?php

use Illuminate\Database\Seeder;

class SecretariaSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
      DB::table('secretarias')->insert([
        'id_secretaria' => '3',
        'nombre' => 'Sergio',
        'telefono' => '+56977777777'
      ]);
    }
}
