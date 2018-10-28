<?php

use Illuminate\Database\Seeder;

class PonderacionesRamoSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('ponderaciones_ramos')->insert([
	        'id_ramo' => '1',
	        'N_nota' => '1',
	        'P_nota' => '0.20'
	    ]);
    }
}
