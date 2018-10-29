<?php

use Illuminate\Database\Seeder;

class HistorialSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('historiales')->insert([
	        'id_asignatura' => 'ICI-116',
	        'id_alumno' => '1',
	        'estado' => 'Aprobado',
	        'Semestre' => '1',
	        'nota_final'=>'4'
      	]);
    }
}
