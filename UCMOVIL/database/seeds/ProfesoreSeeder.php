<?php

use Illuminate\Database\Seeder;

class ProfesoreSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
      DB::table('profesores')->insert([
        'id_profesor' => '2',
        'ano_ingreso' => '2015',
        'especialidad' => 'Programador',
        'nombre' => 'Savio',
        'telefono' => '+56988888888'
      ]);
    }
}
