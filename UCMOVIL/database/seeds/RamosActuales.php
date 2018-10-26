<?php

use Illuminate\Database\Seeder;

class RamosActuales extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
    	DB::table('ramos_actuales')->insert([
	        'id_asignatura' => 'ICI-427',
	        'id_alumno' => '1',
	        'nota' => '4',
	        'n_nota' => '4',
	        'created_at' => '2018-10-24'
	    ]);
    }
}
