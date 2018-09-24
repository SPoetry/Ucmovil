<?php

use Illuminate\Database\Seeder;

class AlumnoSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
      DB::table('alumnos')->insert([
        'id' => '1',
        'ano_ingreso' => '0001/01/01',
        'nombre' => 'Tiano',
        'ano_nacimiento' => '1995',
        'telefono' => '+56999999999',
        'direccion' => 'El campo, bien lejos',
        'semestre_actual' => '9',
      ]);
    }
}
