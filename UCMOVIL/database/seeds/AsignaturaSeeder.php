<?php

use Illuminate\Database\Seeder;

class AsignaturaSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-400',
        'nombre' => 'Programacion',
        'creditos' => '8',
        'pre-requisito' => 'Ninguno'
      ]);
    }
}
