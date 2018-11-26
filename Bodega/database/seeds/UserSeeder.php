<?php

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;
use App\User;

class UserSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
      /*  DB::table('users')->insert([
            'id_usuario'=> '041',
            'nombre' => 'Savio',
            'dpto' => '001',
            'clave' => bcrypt('sak')
        ]);*/

        DB::statement('SET FOREIGN_KEY_CHECKS=0;');
        DB::table('users')->truncate();
        DB::statement('SET FOREIGN_KEY_CHECKS=1;');

        User::create([
              'id'=> '001',
              'nombre' => 'Administrador',
              'dpto' => '001',
              'password' => bcrypt('admin'),
              'rol' => '0'
          ]);

        User::create([
              'id'=> '002',
              'nombre' => 'Adquisiciones',
              'dpto' => '002',
              'password' => bcrypt('adqui'),
              'rol' => '1'
          ]);

        User::create([
              'id'=> '003',
              'nombre' => 'Solicitante',
              'dpto' => '003',
              'password' => bcrypt('soli'),
              'rol' => '2'
          ]);

        factory(User::class)->create();
    }
}
