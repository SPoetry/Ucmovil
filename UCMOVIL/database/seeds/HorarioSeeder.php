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
		DB::statement('SET FOREIGN_KEY_CHECKS=0;');
		DB::table('horarios')->truncate();
		DB::statement('SET FOREIGN_KEY_CHECKS=1;');

        DB::table('horarios')->insert([
	        'id_asignatura' => 'ICI-612',
	        'modulo' => '1',
	        'dia' => 'lunes',
	        'sala' => '24',
          'estado'=> 'Aceptada'
	    ]);
	    DB::table('horarios')->insert([
	        'id_asignatura' => 'ICI-115',
	        'modulo' => '2',
	        'dia' => 'lunes',
	        'sala' => '24',
          'estado'=> 'Aceptada'
	    ]);
	    DB::table('horarios')->insert([
	        'id_asignatura' => 'ICI-612',
	        'modulo' => '2',
	        'dia' => 'martes',
	        'sala' => '24',
          'estado'=> 'Aceptada'
	    ]);
    }
}
