<?php

use Illuminate\Database\Seeder;

class RamosActualeSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
    	DB::table('ramos_actuales')->insert([
	        'id_asignatura' => 'ICI-114',
	        'id_alumno' => '1',
	        'nota' => '4.1',
	        'n_nota' => '4',
	        'created_at' => '2018-10-24 14:57:29'
	    ]);
    }
}
