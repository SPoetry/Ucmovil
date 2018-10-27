<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreatePonderacionesRamosTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('ponderaciones_ramos', function (Blueprint $table) {
          $table->integer('id_ramoimpartido')->unsigned();
          $table->integer('N_nota');
          $table->float('P_nota');
          $table->timestamps();
          $table->primary('id_ramoimpartido');
          $table->foreign('id_ramoimpartido')->references('id_ramoimpartido')->on('ramos_impartidos');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('ponderaciones_ramos');
    }
}
