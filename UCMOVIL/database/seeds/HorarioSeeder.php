<?php

use Illuminate\Database\Seeder;

class HorarioSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('horarios')->insert([
	        'id_asignatura' => 'ICI-114',
	        'modulo' => '1',
	        'dia' => 'lunes',
	        'sala' => '24',
	    ]);
	    DB::table('horarios')->insert([
	        'id_asignatura' => 'ICI-114',
	        'modulo' => '2',
	        'dia' => 'lunes',
	        'sala' => '24',
	    ]);
	    DB::table('horarios')->insert([
	        'id_asignatura' => 'ICI-114',
	        'modulo' => '2',
	        'dia' => 'martes',
	        'sala' => '24',
	    ]);
    }
}
