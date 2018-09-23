<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateDirectoresCarrerasTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('directores_carreras', function (Blueprint $table) {
          $table->integer('id_director')->unsigned();
          $table->string('especialidad');
          $table->string('nombre');
          $table->string('telefono');
          $table->timestamps();
          $table->primary('id_director');
          $table->foreign('id_director')->references('id')->on('users');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('directores_carreras');
    }
}
