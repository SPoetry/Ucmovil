<?php

use Illuminate\Database\Seeder;

class DirectoresCarreraSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
      DB::table('directores_carreras')->insert([
        'id_director' => '1',
        'especialidad' => 'Programador',
        'nombre' => 'Erik',
        'telefono' => '+56966666666'
      ]);
    }
}