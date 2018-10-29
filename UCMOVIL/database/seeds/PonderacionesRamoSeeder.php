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

      for ($i=1; $i <= 10; $i++) {
        DB::table('ponderaciones_ramos')->insert([
            'id_ramo' => '1',
            'N_nota' => $i,
<<<<<<< HEAD
            'P_nota' => '0'
=======
            'P_nota' => '0.2'
>>>>>>> c407f2917650866b106d57c6c14bfcf27f015ba7
          ]);
      }

      for ($i=1; $i <= 10; $i++) {
        DB::table('ponderaciones_ramos')->insert([
            'id_ramo' => '2',
            'N_nota' => $i,
<<<<<<< HEAD
            'P_nota' => '0'
          ]);
      }

        DB::table('ponderaciones_ramos')->insert([
	        'id_ramo' => '1',
	        'N_nota' => '1',
	        'P_nota' => '0.20'
	    ]);
<<<<<<< HEAD
	    DB::table('ponderaciones_ramos')->insert([
	        'id_ramo' => '2',
	        'N_nota' => '1',
	        'P_nota' => '0.20'
	    ]);
=======

>>>>>>> 1de90cd5dd869aa3629a122ad69c6f8ebaea7482
=======
            'P_nota' => '0.2'
          ]);
      }
>>>>>>> c407f2917650866b106d57c6c14bfcf27f015ba7
    }
}
